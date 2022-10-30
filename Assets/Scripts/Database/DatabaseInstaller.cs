using System;
using UnityEngine;
using UnityEngine.Networking;
using Zenject;
using NaughtyAttributes;
using System.IO;
using System.Threading.Tasks;

namespace Database
{
    public class DatabaseInstaller : MonoInstaller
    {
        [SerializeField] private string _itemsSheetId = "1PzsekMDmxh5I6I3Y-O2N8nBWuFn5541YfM1OWYjQ2iQ";
        private readonly string _sheetURLTemplate = "https://docs.google.com/spreadsheets/d/*/export?format=csv";
        private bool _isDownloading = false;
        private bool _canDownload = true;

        public override void InstallBindings()
        {
            BindItemDatabase();
        }

        private void BindItemDatabase()
        {
            Container
                .Bind<ItemDatabase>()
                .FromNew()
                .AsSingle();
        }

        [Button("Update items sheet"), ShowIf("_canDownload")]
        private void UpdateItemsSheet() => DownloadSheetAsync(_sheetURLTemplate.Replace("*", _itemsSheetId), "ItemsSheet");

        private async void DownloadSheetAsync(string url, string name)
        {
            _isDownloading = true;
            _canDownload = false;

            using (UnityWebRequest request = UnityWebRequest.Get(url))
            {
                UnityWebRequestAsyncOperation operation = request.SendWebRequest();

                while (operation.isDone == false)
                {
                    await Task.Yield();
                }

                switch (request.result)
                {
                    case UnityWebRequest.Result.ConnectionError:
                    case UnityWebRequest.Result.ProtocolError:
                    case UnityWebRequest.Result.DataProcessingError:
                        {
                            throw new Exception("Failed to download");
                        }
                }

                await File.WriteAllTextAsync($"{Application.dataPath}/Resources/Database/{name}.txt", request.downloadHandler.text);
            }

            _isDownloading = false;
            _canDownload = true;
        }
    }
}

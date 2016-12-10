using FranceVacances.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Storage;
using Newtonsoft.Json;

namespace FranceVacances.Persistency
{

    class Save
    {

        public async Task<int> Serialize(ObservableCollection<RentalModel> instance)
        {
            string content = string.Empty;
            var serializer = new JsonSerializer();
            content = JsonConvert.SerializeObject(instance, Formatting.Indented);
            StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync("offers.xml", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, content);

            return content.Length / 1024;
        }

        public async Task<RentalModel> Deserialize()
        {
            StorageFile file = await ApplicationData.Current.LocalFolder.GetFileAsync("offers.xml");
            string content = await FileIO.ReadTextAsync(file);

            return JsonConvert.DeserializeObject<RentalModel>(content);
        }

    }
}

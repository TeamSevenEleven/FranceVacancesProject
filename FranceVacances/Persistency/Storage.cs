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

    public sealed class SaveRentals
    {

        public async Task<int> SerializeRentals(ObservableCollection<RentalModel> instance)
        {
            string content = string.Empty;
            var serializer = new JsonSerializer();
            content = JsonConvert.SerializeObject(instance, Formatting.Indented);
            StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync("offers.json", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, content);

            return content.Length / 1024;
        }

        public async Task<ObservableCollection<RentalModel>> DeserializeRentals()
        {
            StorageFile file = await ApplicationData.Current.LocalFolder.GetFileAsync("offers.json");
            string content = await FileIO.ReadTextAsync(file);

            return JsonConvert.DeserializeObject<ObservableCollection<RentalModel>>(content);
        }

    }
    public sealed class SaveUsers
    {
        public async Task<int> SerializeUsers(ObservableCollection<User> instance)
        {
            string content = string.Empty;
            var serializer = new JsonSerializer();
            content = JsonConvert.SerializeObject(instance, Formatting.Indented);
            StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync("users.json", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, content);

            return content.Length / 1024;
        }

        public async Task<ObservableCollection<User>> DeserializeUsers()
        {
            StorageFile file = await ApplicationData.Current.LocalFolder.GetFileAsync("users.json");
            string content = await FileIO.ReadTextAsync(file);

            return JsonConvert.DeserializeObject<ObservableCollection<User>>(content);
        }

    }
}

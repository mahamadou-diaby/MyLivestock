using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace MyLiveStock.DataContrats
{
    public interface IRepository
    {
        Rabbit GetRabbit(string id);
        List<Rabbit> GetRabbits();
        Productrice GetProductrice(string id);
        List<Productrice> GetProductrices();
        MiseBas GetMiseBas(string id);
        List<MiseBas> GetMiseBas();
        Saillie GetSaillie(string id);
        List<Saillie> GetSaillies();
        List<Evenement> GetEvenement();
        string CreateRabbit(string matricule, string color, DateTime date, string type, string gender, string fileName, string poids);
        string UpdateRabbit(string id, string matricule, DateTime date, string type, string gender, string color, string fileName, string poids);
        void DeleteRabbit(string id);
        string CreateMiseBas(string id, string observation, string idSaillie, int portee, DateTime date, string idMale);
        void DeleteMiseBas(string id);
        string CreateSaillie(string id, string observation, DateTime date, string idMale);
        void DeleteSaillie(string id, string idRabbit);
        string UpdateSaillie(string id, string observation, DateTime date, string idMale, string idSaillie);
        void DeathNote(string id, string mat, DateTime date, string cause);
        void SevrateYoungRabbit(string idRabbit, string matMisebas);

    }
}

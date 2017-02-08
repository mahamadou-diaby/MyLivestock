using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLiveStock.DataContrats;
using Entity;
using System.Data.Entity;
using Entity.Transactions;
using System.Globalization;

namespace MyLiveStock.DataAccess
{
    public class Repository : IRepository
    {
        private ContextRepository _Contextrepository;

        public Repository()
        {
            _Contextrepository = new ContextRepository();
        }


        // GET METHODES
        public Rabbit GetRabbit(string id)
        {
            var rabbit = _Contextrepository.Rabbits.FirstOrDefault(r => r.Id == id);
            return rabbit;
        }

        public List<Rabbit> GetRabbits()
        {
            var rabbit = _Contextrepository.Rabbits.ToList();
            return rabbit;
        }

        public Productrice GetProductrice(string id)
        {
            var rabbit = _Contextrepository.Productrice.FirstOrDefault(r => r.Id == id);
            return rabbit;
        }

        public List<Productrice> GetProductrices()
        {
            var rabbit = _Contextrepository.Productrice.ToList();
            return rabbit;
        }

        public MiseBas GetMiseBas(string id)
        {
            var miseBas = _Contextrepository.MiseBas.FirstOrDefault(r => r.Id == id);
            return miseBas;
        }

        public List<MiseBas> GetMiseBas()
        {
            var miseBas = _Contextrepository.MiseBas.ToList();
            return miseBas;
        }

        public Saillie GetSaillie(string id)
        {
            var saillie = _Contextrepository.Saillies.FirstOrDefault(r => r.Id == id);
            return saillie;
        }

        public List<Saillie> GetSaillies()
        {
            var saillie = _Contextrepository.Saillies.ToList();
            return saillie;
        }

        public List<Evenement> GetEvenement()
        {
            var evenement = _Contextrepository.Evenements.ToList();
            return evenement;
        }

        // CREATE METHODES
        

        public string CreateRabbit(string matricule, string color, DateTime date, string type, string gender, string fileName, string poids)
        {
            string id;
            if ((RabbitType)Convert.ToInt32(type) == RabbitType.Productrice)
            {
                Productrice productrice = new Productrice
                {
                    Id = Guid.NewGuid().ToString(),
                    Color = color,
                    PictureName = fileName,
                    Date = date,
                    Type = (RabbitType)Convert.ToInt32(type),
                    Gender = (RabbitGender)Convert.ToInt32(type),
                    Matricule = string.IsNullOrWhiteSpace(matricule) ? Guid.NewGuid().ToString().Substring(0, 4).ToUpper() : matricule,
                    Poids = Convert.ToInt32(poids)
                };

                _Contextrepository.Rabbits.Add(productrice);
                id = productrice.Id;
            }
            else
            {
                Rabbit rabbit = new Rabbit
                {
                    Id = Guid.NewGuid().ToString(),
                    Color = color,
                    Date = date,
                    Type = (RabbitType)Convert.ToInt32(type),
                    Gender = (RabbitGender)Convert.ToInt32(type),
                    Matricule = string.IsNullOrWhiteSpace(matricule) ? Guid.NewGuid().ToString().Substring(0, 4).ToUpper() : matricule
                };

                _Contextrepository.Rabbits.Add(rabbit);
                id = rabbit.Id;
            }
            
            
            _Contextrepository.SaveChanges();                    
            return id;
        }

        public string CreateMiseBas(string id, string observation, string idSaillie, int portee, DateTime date, string idMale)
        {
            var rabbit = _Contextrepository.Productrice.FirstOrDefault(r => r.Id == id);
            var saillie = _Contextrepository.Saillies.FirstOrDefault(s => s.Id == idSaillie);
            saillie.status = StatuSaillie.Reussit;
            MiseBas miseBas = new MiseBas
            {
                Id = Guid.NewGuid().ToString(),
                Observation = observation,
                Portee = portee,
                Date = date,
                IdMaleSaillant = idMale,
                IdSaillie = saillie.MatriculeSaillie, 
                MatriculeMisebas = "Mis-" + Guid.NewGuid().ToString().Substring(0, 3).ToUpper(),
                
            };
            miseBas.Evenement = new Evenement
            {
                Id = "Event-" + Guid.NewGuid().ToString().Substring(0, 3).ToUpper(),
                Title = "Saillie de lapine " + rabbit.Matricule,
                Date = date.AddDays(15).ToString("yyyy-MM-dd"),
                MatriculeRabbit = rabbit.Matricule
            };
            rabbit.MiseBas.Add(miseBas);

            for (int i = 0; i < portee; i++)
            {
                Rabbit rabit = new Rabbit
                {
                    Id = Guid.NewGuid().ToString(),
                    Date = date,
                    Type = RabbitType.Laperau,
                    IdPere = idMale,
                    IdMere = rabbit.Matricule,
                    Matricule = Guid.NewGuid().ToString().Substring(0, 3).ToUpper(),
                    matriculeMisebas = miseBas.MatriculeMisebas,
                    Poids = 55
                };
                _Contextrepository.Rabbits.Add(rabit);
            }
            //_Contextrepository.Rabbits.Add(rabbit);
            _Contextrepository.SaveChanges();

            return rabbit.Id;
        }

        public string CreateSaillie(string id, string observation, DateTime date, string idMale)
        {
            var rabbit = _Contextrepository.Productrice.FirstOrDefault(r => r.Id == id);
            Saillie saillie = new Saillie
            {
                Id = Guid.NewGuid().ToString(),
                Observation = observation,
                Date = date,
                IdMaleSaillant = idMale,
                NextMiseBas = date.AddDays(31),
                status = StatuSaillie.EnCour,
                MatriculeSaillie = "SAI-"+ Guid.NewGuid().ToString().Substring(0, 3).ToUpper(),

            };

            saillie.Evenement.Add(new Evenement
            {
                Id = "Event-" + Guid.NewGuid().ToString().Substring(0, 3).ToUpper(),
                Title = "Boîte à nid pour lapine " + rabbit.Matricule,
                Date = date.AddDays(29).ToString("yyyy-MM-dd"),
                MatriculeRabbit = rabbit.Matricule
            });
            saillie.Evenement.Add(
                new Evenement
                {
                    Id = "Event-" + Guid.NewGuid().ToString().Substring(0, 3).ToUpper(),
                    Title = "Mise bas de lapine " + rabbit.Matricule,
                    Date = saillie.NextMiseBas.ToString("yyyy-MM-dd"),
                    MatriculeRabbit = rabbit.Matricule
                });
            rabbit.Saillie.Add(saillie);
            //_Contextrepository.Rabbits.Add(rabbit);
            _Contextrepository.SaveChanges();

            return rabbit.Id;
        }

        // DELETE METHODES
        public void DeleteRabbit(string id)
        {
            var rabbit = _Contextrepository.Rabbits.FirstOrDefault(r => r.Id == id);
            _Contextrepository.Rabbits.Remove(rabbit);
            _Contextrepository.SaveChanges();
        }        

        public void DeleteMiseBas(string id)
        {
            var miseBas = _Contextrepository.MiseBas.FirstOrDefault(r => r.Id == id);
            
            _Contextrepository.MiseBas.Remove(miseBas);
            _Contextrepository.SaveChanges();
        }        

        public void DeleteSaillie(string id, string idRabbit)
        {
            var rabbit = _Contextrepository.Productrice.FirstOrDefault(r => r.Id == idRabbit);
            var sail = rabbit.Saillie.FirstOrDefault(s => s.Id == id);
            var misebas = rabbit.MiseBas.FirstOrDefault(m => m.IdSaillie == sail.MatriculeSaillie);
            var lapereau = this.GetRabbits().Where(l => l.matriculeMisebas == misebas.MatriculeMisebas);
            rabbit.Saillie.Remove(sail);
            rabbit.MiseBas.Remove(misebas);
            foreach(var rab in lapereau)
            {
                _Contextrepository.Rabbits.Remove(rab);
            }            
            _Contextrepository.SaveChanges();
        }

        public void DeathNote(string idRabbit, string matMisebas, DateTime date, string cause)
        {
            var productrice = _Contextrepository.Productrice.FirstOrDefault(p => p.Id == idRabbit);
            //var misebas = productrice.MiseBas.FirstOrDefault(m => m.MatriculeMisebas == matMisebas);
            productrice.MiseBas.FirstOrDefault(m => m.MatriculeMisebas == matMisebas).Deaths.Add(
                new Death
                {
                    Id = "Death-" + Guid.NewGuid().ToString().Substring(0, 3).ToUpper(),
                    Date = date,
                    Cause = cause
                });            
            _Contextrepository.SaveChanges();
        }

        // UPDATE METHODES
        public string UpdateSaillie(string id, string observation, DateTime date, string idMale, string idSaillie)
        {
            var rabbit = _Contextrepository.Productrice.FirstOrDefault(r => r.Id == id);
            foreach(var saillie in rabbit.Saillie)
            {
                if(saillie.Id == idSaillie)
                {
                    saillie.Observation = observation;
                    saillie.Date = date;
                    saillie.IdMaleSaillant = idMale;
                }
            }
            _Contextrepository.Rabbits.Add(rabbit);
            _Contextrepository.SaveChanges();

            return rabbit.Id;
        }

        public string UpdateRabbit(string id, string matricule, DateTime date, string type, string gender, string color, string fileName, string poids)
        {
            var rabbit = this.GetRabbit(id);
            if(rabbit != null)
            {
                rabbit.Color = color;
                rabbit.Matricule = matricule;
                rabbit.Date = date;
                rabbit.Type = (RabbitType)Convert.ToInt32(type);
                rabbit.Gender = (RabbitGender)Convert.ToInt32(gender);
                rabbit.Poids = Convert.ToInt32(poids);
                if(!string.IsNullOrWhiteSpace(fileName))
                {
                    rabbit.PictureName = fileName;
                }
                _Contextrepository.SaveChanges();
            }
            return id;
        }

        public void SevrateYoungRabbit(string idRabbit, string matMisebas)
        {
            var rabbit = this.GetRabbits().Where(r => r.matriculeMisebas == matMisebas);
            foreach(var rab in rabbit)
            {
                rab.Type = RabbitType.Engraissement;
            }

            var productrice = this.GetProductrice(idRabbit);
            productrice.MiseBas.FirstOrDefault(m => m.MatriculeMisebas == matMisebas).IsSevrate = true;
            _Contextrepository.SaveChanges();
        }
    }
}

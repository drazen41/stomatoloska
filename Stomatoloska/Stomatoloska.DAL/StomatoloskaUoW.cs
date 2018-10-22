using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stomatoloska.DAL.Baza;
using Stomatoloska.DAL.Repository;

namespace Stomatoloska.DAL
{
    public class StomatoloskaUoW :IDisposable 
    {
        private stomatoloskaEntities context = new stomatoloskaEntities();
        private RadnoVrijemeRepo radnoVrijemeRepo;
        private StomatoloskaRepo<Zahvat> zahvatRepo;
        private PacijentRepo pacijentRepo;
        private StomatoloskaRepo<Narudzba> narudzbaRepo;
        public StomatoloskaRepo<Narudzba> NarudzbaRepo
        {
            get
            {
                if (narudzbaRepo == null) narudzbaRepo = new StomatoloskaRepo<Narudzba>(context);
                return narudzbaRepo;
            }
        }
        public PacijentRepo PacijentRepo
        {
            get
            {
                if (pacijentRepo == null) pacijentRepo = new PacijentRepo(context);
                return pacijentRepo;
            }
        } 
        public RadnoVrijemeRepo RadnoVrijemeRepo
        {
            get
            {
                if (this.radnoVrijemeRepo == null)
                {
                    this.radnoVrijemeRepo = new RadnoVrijemeRepo(context);
                }
                return radnoVrijemeRepo;
            }
        }
        public StomatoloskaRepo<Zahvat> ZahvatRepo
        {
            get
            {
                if (this.zahvatRepo == null)
                {
                    this.zahvatRepo = new StomatoloskaRepo<Zahvat>(context);
                }
                return zahvatRepo;
            }
        }
        public void Spremi()
        {
            context.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);

        }
    }
}

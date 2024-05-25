using System;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.ComponentModel.DataAnnotations.Schema;

namespace SDD2.models
{
    
    public class DataBase : DbContext
    {
       
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Documento> Documentos { get; set; }        
        public DbSet<TipoDocumento> TiposDocumentos { get; set; }

        public DbSet<AnoEscolar> AnosEscolar { get; set; }
        public DbSet<Grado> Grados { get; set; }
        public DbSet<Nivel> Niveles { get; set; }
        public DbSet<Seccion> Secciones { get; set; }
        public DbSet<Turno> Turnos { get; set; }
        public DataBase() :base("name=LocalDbConnection") //SDDConexion
        {
            
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Llamar a la implementación base primero
            //base.OnModelCreating(modelBuilder);                       
            modelBuilder.Entity<Documento>().ToTable("Documentos"); // Especifica el nombre de tabla exacto
            modelBuilder.Entity<TipoDocumento>().ToTable("TiposDocumentos"); // Especifica el nombre de tabla exacto
            modelBuilder.Entity<AnoEscolar>().ToTable("AnosEscolar"); // Especifica el nombre de tabla exacto
            modelBuilder.Entity<Grado>().ToTable("Grados"); // Especifica el nombre de tabla exacto
            modelBuilder.Entity<Nivel>().ToTable("Niveles"); // Especifica el nombre de tabla exacto
            modelBuilder.Entity<Seccion>().ToTable("Secciones"); // Especifica el nombre de tabla exacto
            modelBuilder.Entity<Turno>().ToTable("Turnos"); // Especifica el nombre de tabla exacto
            modelBuilder.Entity<Usuario>().ToTable("Usuarios"); // Especifica el nombre de tabla exacto

        }

        public void initializeModel()
        {
            this.Usuarios.Add(new Usuario
            {
                Nombre = "FAZ2024",
                Clave = "123"
            });
            
            this.SaveChanges();

            this.TiposDocumentos.Add(new TipoDocumento { Nombre = "ACTA CONSOLIDADA" });
            this.SaveChanges();
            this.TiposDocumentos.Add(new TipoDocumento { Nombre = "FICHA MATRICULA" });
            this.SaveChanges();
            this.TiposDocumentos.Add(new TipoDocumento { Nombre = "CONSTANCIA DE ESTUDIO" });
            this.SaveChanges();
            this.TiposDocumentos.Add(new TipoDocumento { Nombre = "OTROS" });
            this.SaveChanges();

            int AnioInicio = 1950;
            int AnioFin = 2024;

            for(int i= AnioInicio; i<= AnioFin;i++) {
                this.AnosEscolar.Add(new AnoEscolar { Ano = i });
                this.SaveChanges();
            }

            this.Niveles.Add(new Nivel { Nombre = "INICIAL" });
            this.SaveChanges();
            this.Niveles.Add(new Nivel { Nombre = "PRIMARIA" });
            this.SaveChanges();
            this.Niveles.Add(new Nivel { Nombre = "SECUNDARIA" });
            this.SaveChanges();

            this.Grados.Add(new Grado { Nombre = "1° PRIMERO" });
            this.SaveChanges();
            this.Grados.Add(new Grado { Nombre = "2° SEGUNDO" });
            this.SaveChanges();
            this.Grados.Add(new Grado { Nombre = "3° TERCERO" });
            this.SaveChanges();
            this.Grados.Add(new Grado { Nombre = "4° CUARTO" });
            this.SaveChanges();
            this.Grados.Add(new Grado { Nombre = "5° QUINTO" });
            this.SaveChanges();

            for (char letra = 'A'; letra <= 'Z'; letra++)
            {
                this.Secciones.Add(new Seccion { Nombre = letra.ToString() });
                this.SaveChanges();
            }
            
            this.SaveChanges();
            this.Turnos.Add(new Turno { Nombre = "DIURNO (MAÑANA)" });
            this.SaveChanges();
            this.Turnos.Add(new Turno { Nombre = "TARDE" });
            this.SaveChanges();
            this.Turnos.Add(new Turno { Id=0, Nombre = "AMBOS" });
            this.SaveChanges();

        }

        public int create<T>(T objeto) where T : class
        {
            this.Set<T>().Add(objeto);
            return this.SaveChanges();
        }
    
        public List<T> list<T>() where T : class
        {
            return this.Set<T>().ToList();
        }

        public int update<T>(Func<T,bool> condicion,Func<T,T> callback) where T : class
        {
            var objeto = this.Set<T>().FirstOrDefault(condicion);
            if (objeto != null) {
                var objetoActualizado = callback(objeto);
                this.Entry(objeto).CurrentValues.SetValues(objetoActualizado);
                return this.SaveChanges();
            }

            return -1;
        }

        public int delete<T>(Func<T, bool> condicion) where T : class
        {
            var objeto = this.Set<T>().FirstOrDefault(condicion);
            if (objeto != null)
            {
                this.Set<T>().Remove(objeto);
                return this.SaveChanges();
            }

            return -1;
        }

        public T get<T>(Func<T, bool> condicion) where T : class
        {
            return this.Set<T>().FirstOrDefault(condicion);
        }

        public List<T> getAll<T>(Func<T, bool> condicion) where T : class
        {
            var listado = this.Set<T>().Where(condicion);
            
            if(listado.Count() > 0) {
                return listado.ToList();
            }
            else
            {
                return null;
            }            
        }

     
    }
}

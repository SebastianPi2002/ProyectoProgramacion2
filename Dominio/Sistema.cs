using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Sistema
    {
        private List<Investigador> _investigadores;
        private List<Caso> _casos;
        private List<Sospechoso> _sospechosos;

        public Sistema()
        {
            _investigadores = new List<Investigador>();
            _casos = new List<Caso>();
            _sospechosos = new List<Sospechoso>();
        }

        // Registra un investigador luego de validar sus datos.
        // Verifica que no sea nulo y que no exista otro
        // investigador registrado con el mismo email.

        public void AltaInvestigador(Investigador investigador)
        {
            if (investigador == null)
            {
                throw new Exception("El investigador no puede ser nulo");
            }

            investigador.Validar();
             
            if (BuscarInvestigador(investigador.Email) != null)
            {
                throw new Exception("Ya existe un investigador con ese email.");
            }

            _investigadores.Add(investigador);
        }

        // Busca un investigador por su email, sin distinguir
        // entre mayúsculas y minúsculas.
        // Si no lo encuentra, devuelve null.

        private Investigador? BuscarInvestigador(string email)
        {
            foreach (Investigador investigador in _investigadores)
            {
                if (investigador.Email.ToLower() == email.ToLower())
                {
                    return investigador;
                }
            }

            return null;
        }

        // Registra un sospechoso luego de validar sus datos
        // y comprobar que no exista otro con la misma cédula.

        public void AltaSospechoso(Sospechoso sospechoso)
        {
                
            if (sospechoso == null)
            {
                throw new Exception("El sospechoso no puede ser nulo");
            }

            sospechoso.Validar();

            if (BuscarSospechoso(sospechoso.Cedula) != null)
            {
                throw new Exception("Ya existe un sospechoso con esa cédula.");
            }

            _sospechosos.Add(sospechoso);
        }

        // Registra un caso luego de validar sus datos
        // y comprobar que no sea nulo.

        public void AltaCaso(Caso caso)
        {

            if (caso == null)
            {
                throw new Exception("El caso no puede ser nulo");
            }

            caso.Validar();

            _casos.Add(caso);
        }

        // Busca un sospechoso por su cédula.
        // Si no existe, devuelve null.

        private Sospechoso? BuscarSospechoso(string cedula)
        {
            foreach (Sospechoso sospechoso in _sospechosos)
            {
                if (sospechoso.Cedula == cedula)
                {
                    return sospechoso;
                }
            }

            return null;
        }

        // Devuelve la lista de todos los casos registrados en el sistema.
        public List<Caso> ObtenerCasos()
        {
            return _casos;
        }


        // Busca los casos asignados a un investigador mediante su email,
        // sin distinguir entre mayúsculas y minúsculas.
        // Devuelve una lista con los casos encontrados.

        public List<Caso> ObtenerCasosPorEmail(string email)
        {
            List<Caso> resultado = new List<Caso>();

            foreach (Caso caso in _casos)
            {
                
                if (caso.Investigador.Email.ToLower() == email.ToLower())
                {
                    resultado.Add(caso);
                }
            }

            return resultado;
        }


        // Precarga investigadores, sospechosos, casos y evidencias
        // ficticias para permitir las pruebas del sistema.

        public void PrecargarDatos()
        {
            // ========================
            // INVESTIGADORES DETECTIVE
            // ========================

            Investigador investigador1 = new Investigador(
                "martin.silva@fiscalia.uy",
                "Martin123",
                "Martín Silva",
                Rol.DETECTIVE
            );
            AltaInvestigador(investigador1);

            Investigador investigador2 = new Investigador(
                "lucia.fernandez@fiscalia.uy",
                "Lucia456",
                "Lucía Fernández",
                Rol.DETECTIVE
            );
            AltaInvestigador(investigador2);

            Investigador investigador3 = new Investigador(
                "diego.rodriguez@fiscalia.uy",
                "Diego789",
                "Diego Rodríguez",
                Rol.DETECTIVE
            );
            AltaInvestigador(investigador3);

            Investigador investigador4 = new Investigador(
                "sofia.pereira@fiscalia.uy",
                "Sofia321",
                "Sofía Pereira",
                Rol.DETECTIVE
            );
            AltaInvestigador(investigador4);

            Investigador investigador5 = new Investigador(
                "nicolas.gomez@fiscalia.uy",
                "Nico654",
                "Nicolás Gómez",
                Rol.DETECTIVE
            );
            AltaInvestigador(investigador5);


            // =====================
            // INVESTIGADORES FISCAL
            // =====================

            Investigador investigador6 = new Investigador(
                "valentina.lopez@fiscalia.uy",
                "Vale123",
                "Valentina López",
                Rol.FISCAL
            );
            AltaInvestigador(investigador6);

            Investigador investigador7 = new Investigador(
                "andres.martinez@fiscalia.uy",
                "Andres456",
                "Andrés Martínez",
                Rol.FISCAL
            );
            AltaInvestigador(investigador7);

            Investigador investigador8 = new Investigador(
                "camila.suarez@fiscalia.uy",
                "Cami789",
                "Camila Suárez",
                Rol.FISCAL
            );
            AltaInvestigador(investigador8);

            Investigador investigador9 = new Investigador(
                "federico.costa@fiscalia.uy",
                "Fede321",
                "Federico Costa",
                Rol.FISCAL
            );
            AltaInvestigador(investigador9);

            Investigador investigador10 = new Investigador(
                "paula.ramos@fiscalia.uy",
                "Paula654",
                "Paula Ramos",
                Rol.FISCAL
            );
            AltaInvestigador(investigador10);

        

            // ============
            // SOSPECHOSOS
            // ============

            Sospechoso sospechoso1 = new Sospechoso(
                "Carlos Méndez",
                "4.521.630-1",
                true,
                new DateTime(1985, 5, 14)
            );
            AltaSospechoso(sospechoso1);

            Sospechoso sospechoso2 = new Sospechoso(
                "Bruno Acosta",
                "5.184.920-3",
                false,
                new DateTime(1992, 9, 22)
            );
            AltaSospechoso(sospechoso2);

            Sospechoso sospechoso3 = new Sospechoso(
                "Mateo Cabrera",
                "4.792.315-6",
                true,
                new DateTime(1988, 2, 3)
            );
            AltaSospechoso(sospechoso3);

            Sospechoso sospechoso4 = new Sospechoso(
                "Rodrigo Núñez",
                "5.321.874-2",
                false,
                new DateTime(1995, 11, 17)
            );
            AltaSospechoso(sospechoso4);

            Sospechoso sospechoso5 = new Sospechoso(
                "Gonzalo Viera",
                "4.638.291-5",
                true,
                new DateTime(1983, 7, 28)
            );
            AltaSospechoso(sospechoso5);

            Sospechoso sospechoso6 = new Sospechoso(
                "Joaquín Castro",
                "5.472.103-8",
                false,
                new DateTime(1998, 1, 11)
            );
            AltaSospechoso(sospechoso6);

            Sospechoso sospechoso7 = new Sospechoso(
                "Sebastián Torres",
                "4.819.562-4",
                true,
                new DateTime(1990, 6, 6)
            );
            AltaSospechoso(sospechoso7);

            Sospechoso sospechoso8 = new Sospechoso(
                "Agustín Morales",
                "5.203.741-9",
                false,
                new DateTime(1994, 3, 19)
            );
            AltaSospechoso(sospechoso8);

            Sospechoso sospechoso9 = new Sospechoso(
                "Santiago Reyes",
                "4.376.918-7",
                true,
                new DateTime(1981, 12, 25)
            );
            AltaSospechoso(sospechoso9);

            Sospechoso sospechoso10 = new Sospechoso(
                "Emiliano Sosa",
                "5.619.284-1",
                false,
                new DateTime(1997, 8, 8)
            );
            AltaSospechoso(sospechoso10);

            Sospechoso sospechoso11 = new Sospechoso(
                "Leonardo Díaz",
                "4.927.350-6",
                true,
                new DateTime(1987, 4, 30)
            );
            AltaSospechoso(sospechoso11);

            Sospechoso sospechoso12 = new Sospechoso(
                "Franco Olivera",
                "5.738.421-3",
                false,
                new DateTime(2000, 10, 15)
            );
            AltaSospechoso(sospechoso12);

            Sospechoso sospechoso13 = new Sospechoso(
                "Mauricio Lima",
                "4.583.127-9",
                true,
                new DateTime(1984, 1, 9)
            );
            AltaSospechoso(sospechoso13);

            Sospechoso sospechoso14 = new Sospechoso(
                "Facundo Pereira",
                "5.346.892-5",
                false,
                new DateTime(1996, 6, 21)
            );
            AltaSospechoso(sospechoso14);

            Sospechoso sospechoso15 = new Sospechoso(
                "Pablo Ríos",
                "4.715.263-8",
                true,
                new DateTime(1989, 3, 12)
            );
            AltaSospechoso(sospechoso15);


            // ======
            // CASOS
            // ======

            Caso caso1 = new Caso(
                "Robo en Pocitos",
                "Robo ocurrido durante la madrugada en una vivienda de Pocitos.",
                false,
                sospechoso1,
                investigador1
            );
            AltaCaso(caso1);

            Caso caso2 = new Caso(
                "Hurto del Centro",
                "Hurto de equipos electrónicos en un comercio del Centro.",
                false,
                sospechoso2,
                investigador2
            );
            AltaCaso(caso2);

            Caso caso3 = new Caso(
                "Fraude Bancario",
                "Investigación por movimientos bancarios fraudulentos.",
                false,
                sospechoso3,
                investigador3
            );
            AltaCaso(caso3);

            Caso caso4 = new Caso(
                "Robo del Puerto",
                "Robo de mercadería almacenada en la zona portuaria.",
                true,
                sospechoso4,
                investigador4
            );
            AltaCaso(caso4);

            Caso caso5 = new Caso(
                "Caso Malvín",
                "Investigación de un ingreso ilegal a una vivienda en Malvín.",
                false,
                sospechoso5,
                investigador5
            );
            AltaCaso(caso5);

            Caso caso6 = new Caso(
                "Operación Parque Rodó",
                "Investigación por robo de un vehículo próximo al Parque Rodó.",
                false,
                sospechoso6,
                investigador1
            );
            AltaCaso(caso6);

            Caso caso7 = new Caso(
                "Incidente Cordón",
                "Robo en un local comercial durante el horario nocturno.",
                true,
                sospechoso7,
                investigador2
            );
            AltaCaso(caso7);

            Caso caso8 = new Caso(
                "Caso Tres Cruces",
                "Investigación por hurto de pertenencias en la terminal.",
                false,
                sospechoso8,
                investigador3
            );
            AltaCaso(caso8);

            Caso caso9 = new Caso(
                "Operación Carrasco",
                "Investigación de un robo cometido en una residencia.",
                false,
                sospechoso9,
                investigador4
            );
            AltaCaso(caso9);

            Caso caso10 = new Caso(
                "Caso Aguada",
                "Investigación por robo de mercadería de un depósito.",
                false,
                sospechoso11,
                investigador5
            );
            AltaCaso(caso10);


            // ====================
            // EVIDENCIAS - CASO 1
            // ====================

            Fisica evidencia1 = new Fisica(
                new DateTime(2026, 9, 10),
                "Destornillador encontrado junto a una ventana forzada.",
                true
            );
            caso1.AltaEvidencia(evidencia1);

            Grabacion evidencia2 = new Grabacion(
                new DateTime(2026, 9, 10),
                "Video de una cámara exterior de la vivienda.",
                4,
                true
            );
            caso1.AltaEvidencia(evidencia2);

            Testimonio evidencia3 = new Testimonio(
                new DateTime(2026, 9, 11),
                "Vecino observó a una persona salir de la vivienda.",
                "Roberto Pérez",
                Credibilidad.Alto
            );
            caso1.AltaEvidencia(evidencia3);

            Fisica evidencia4 = new Fisica(
                new DateTime(2026, 9, 11),
                "Guante encontrado en el jardín de la propiedad.",
                false
            );
            caso1.AltaEvidencia(evidencia4);


            // ====================
            // EVIDENCIAS - CASO 2
            // ====================

            Grabacion evidencia5 = new Grabacion(
                new DateTime(2026, 9, 2),
                "Cámara ubicada frente al comercio.",
                3,
                true
            );
            caso2.AltaEvidencia(evidencia5);

            Fisica evidencia6 = new Fisica(
                new DateTime(2026, 9, 2),
                "Mochila encontrada cerca del comercio.",
                false
            );
            caso2.AltaEvidencia(evidencia6);

            Testimonio evidencia7 = new Testimonio(
                new DateTime(2026, 9, 3),
                "Empleado declaró haber visto al sospechoso.",
                "Ana Gómez",
                Credibilidad.Medio
            );
            caso2.AltaEvidencia(evidencia7);

            Grabacion evidencia8 = new Grabacion(
                new DateTime(2026, 9, 3),
                "Video grabado desde un comercio vecino.",
                2,
                false
            );
            caso2.AltaEvidencia(evidencia8);


            // ====================
            // EVIDENCIAS - CASO 3
            // ====================

            Fisica evidencia9 = new Fisica(
                new DateTime(2026, 8, 20),
                "Documentación bancaria encontrada durante un allanamiento.",
                true
            );
            caso3.AltaEvidencia(evidencia9);

            Testimonio evidencia10 = new Testimonio(
                new DateTime(2026, 8, 21),
                "Declaración de un empleado bancario.",
                "Marcos Suárez",
                Credibilidad.Alto
            );
            caso3.AltaEvidencia(evidencia10);

            Grabacion evidencia11 = new Grabacion(
                new DateTime(2026, 8, 21),
                "Cámara del cajero automático investigado.",
                5,
                true
            );
            caso3.AltaEvidencia(evidencia11);

            Testimonio evidencia12 = new Testimonio(
                new DateTime(2026, 8, 22),
                "Declaración de un cliente del banco.",
                "Laura Díaz",
                Credibilidad.Bajo
            );
            caso3.AltaEvidencia(evidencia12);


            // ====================
            // EVIDENCIAS - CASO 4
            // ====================

            Grabacion evidencia13 = new Grabacion(
                new DateTime(2026, 7, 14),
                "Grabación de seguridad del depósito.",
                4,
                true
            );
            caso4.AltaEvidencia(evidencia13);

            Fisica evidencia14 = new Fisica(
                new DateTime(2026, 7, 14),
                "Herramienta utilizada para abrir un contenedor.",
                true
            );
            caso4.AltaEvidencia(evidencia14);

            Testimonio evidencia15 = new Testimonio(
                new DateTime(2026, 7, 15),
                "Guardia observó movimientos sospechosos.",
                "José Martínez",
                Credibilidad.Alto
            );
            caso4.AltaEvidencia(evidencia15);

            Fisica evidencia16 = new Fisica(
                new DateTime(2026, 7, 15),
                "Prenda encontrada dentro del depósito.",
                false
            );
            caso4.AltaEvidencia(evidencia16);


            // ====================
            // EVIDENCIAS - CASO 5
            // ====================

            Fisica evidencia17 = new Fisica(
                new DateTime(2026, 6, 5),
                "Vaso encontrado dentro de la vivienda.",
                true
            );
            caso5.AltaEvidencia(evidencia17);

            Grabacion evidencia18 = new Grabacion(
                new DateTime(2026, 6, 5),
                "Cámara ubicada en la entrada.",
                2,
                false
            );
            caso5.AltaEvidencia(evidencia18);

            Testimonio evidencia19 = new Testimonio(
                new DateTime(2026, 6, 6),
                "Vecina escuchó ruidos durante la madrugada.",
                "María Rodríguez",
                Credibilidad.Medio
            );
            caso5.AltaEvidencia(evidencia19);

            Grabacion evidencia20 = new Grabacion(
                new DateTime(2026, 6, 6),
                "Cámara de una vivienda cercana.",
                4,
                true
            );
            caso5.AltaEvidencia(evidencia20);


            // ====================
            // EVIDENCIAS - CASO 6
            // ====================

            Fisica evidencia21 = new Fisica(
                new DateTime(2026, 5, 1),
                "Herramienta encontrada junto al vehículo.",
                false
            );
            caso6.AltaEvidencia(evidencia21);

            Grabacion evidencia22 = new Grabacion(
                new DateTime(2026, 5, 1),
                "Cámara del estacionamiento.",
                5,
                true
            );
            caso6.AltaEvidencia(evidencia22);

            Testimonio evidencia23 = new Testimonio(
                new DateTime(2026, 5, 2),
                "Testigo vio al sospechoso junto al automóvil.",
                "Pedro López",
                Credibilidad.Alto
            );
            caso6.AltaEvidencia(evidencia23);

            Fisica evidencia24 = new Fisica(
                new DateTime(2026, 5, 2),
                "Botella encontrada dentro del vehículo.",
                true
            );
            caso6.AltaEvidencia(evidencia24);


            // ====================
            // EVIDENCIAS - CASO 7
            // ====================

            Testimonio evidencia25 = new Testimonio(
                new DateTime(2026, 4, 10),
                "Empleado observó el ingreso del sospechoso.",
                "Lucía Alonso",
                Credibilidad.Alto
            );
            caso7.AltaEvidencia(evidencia25);

            Grabacion evidencia26 = new Grabacion(
                new DateTime(2026, 4, 10),
                "Video de seguridad del local.",
                3,
                true
            );
            caso7.AltaEvidencia(evidencia26);

            Fisica evidencia27 = new Fisica(
                new DateTime(2026, 4, 11),
                "Bolsa encontrada dentro del comercio.",
                true
            );
            caso7.AltaEvidencia(evidencia27);

            Testimonio evidencia28 = new Testimonio(
                new DateTime(2026, 4, 11),
                "Persona ubicada frente al comercio declaró lo sucedido.",
                "Andrés Costa",
                Credibilidad.Bajo
            );
            caso7.AltaEvidencia(evidencia28);


            // ====================
            // EVIDENCIAS - CASO 8
            // ====================

            Grabacion evidencia29 = new Grabacion(
                new DateTime(2026, 3, 12),
                "Grabación de una cámara de la terminal.",
                4,
                true
            );
            caso8.AltaEvidencia(evidencia29);

            Testimonio evidencia30 = new Testimonio(
                new DateTime(2026, 3, 12),
                "Pasajero vio el momento del hurto.",
                "Carolina Ramos",
                Credibilidad.Medio
            );
            caso8.AltaEvidencia(evidencia30);

            Fisica evidencia31 = new Fisica(
                new DateTime(2026, 3, 13),
                "Objeto abandonado próximo al lugar.",
                false
            );
            caso8.AltaEvidencia(evidencia31);

            Grabacion evidencia32 = new Grabacion(
                new DateTime(2026, 3, 13),
                "Grabación desde otro sector de la terminal.",
                2,
                false
            );
            caso8.AltaEvidencia(evidencia32);


            // ====================
            // EVIDENCIAS - CASO 9
            // ====================

            Fisica evidencia33 = new Fisica(
                new DateTime(2026, 2, 20),
                "Herramienta encontrada en el patio.",
                true
            );
            caso9.AltaEvidencia(evidencia33);

            Grabacion evidencia34 = new Grabacion(
                new DateTime(2026, 2, 20),
                "Cámara de seguridad de la residencia.",
                5,
                true
            );
            caso9.AltaEvidencia(evidencia34);

            Testimonio evidencia35 = new Testimonio(
                new DateTime(2026, 2, 21),
                "Jardinero observó al sospechoso cerca de la vivienda.",
                "Fernando Silva",
                Credibilidad.Alto
            );
            caso9.AltaEvidencia(evidencia35);

            Fisica evidencia36 = new Fisica(
                new DateTime(2026, 2, 21),
                "Gorra encontrada junto a una puerta lateral.",
                false
            );
            caso9.AltaEvidencia(evidencia36);


            // =====================
            // EVIDENCIAS - CASO 10
            // =====================

            Grabacion evidencia37 = new Grabacion(
                new DateTime(2026, 1, 15),
                "Grabación del interior del depósito.",
                3,
                true
            );
            caso10.AltaEvidencia(evidencia37);

            Fisica evidencia38 = new Fisica(
                new DateTime(2026, 1, 15),
                "Caja manipulada durante el robo.",
                true
            );
            caso10.AltaEvidencia(evidencia38);

            Testimonio evidencia39 = new Testimonio(
                new DateTime(2026, 1, 16),
                "Trabajador declaró haber visto al sospechoso.",
                "Natalia Fernández",
                Credibilidad.Medio
            );
            caso10.AltaEvidencia(evidencia39);

            Grabacion evidencia40 = new Grabacion(
                new DateTime(2026, 1, 16),
                "Grabación de una cámara exterior.",
                1,
                false
            );
            caso10.AltaEvidencia(evidencia40);
        }

        public List<Sospechoso> ObtenerSospechososConAntecedentes()
        {
            List<Sospechoso> sospechososConAntecedentes = new List<Sospechoso>();

            foreach (Sospechoso sospechoso in _sospechosos)
            {
                if (sospechoso.Antecedentes)
                {
                    sospechososConAntecedentes.Add(sospechoso);
                }
            }

            return sospechososConAntecedentes;
        }

    }


    }
    




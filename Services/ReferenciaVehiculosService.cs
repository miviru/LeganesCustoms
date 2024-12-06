public class ReferenciaVehiculosService
{
    private readonly Dictionary<string, List<string>> _modelosPorFabricante;
    private readonly Dictionary<string, Dictionary<string, List<string>>> _motoresPorModelo;

    public ReferenciaVehiculosService()
    {
        _modelosPorFabricante = new Dictionary<string, List<string>>
        {
            { "Alpine", new List<string> { "A106", "A108", "A110", "A290", "A310", "GTA", "A610", "Otro" } },
            { "Dacia", new List<string> { "Duster", "Logan", "Lodgy", "Dokker", "Sandero", "Jogger", "Spring", "Otro" } },
            { "Nissan", new List<string> { "Altima", "Leaf", "Qashqai", "Ariya", "Juke", "Townstar", "X-Trail", "400z", "350z", "370z", "GTR", "Otro" } },
            { "Toyota", new List<string> { "Aygo X", "bZ4X", "C-HR", "Corolla Cross","Corolla", "Camry", "Highlander", "Hilux", "Land Cruiser", "Mirai", "Prius", "Proace", "Proace City", "Rav4", "Supra", "Yaris", "Yaris Cross", "Aygo", "Auris", "GT86", "Otro" } },
            { "Ford", new List<string> { "Fiesta", "Focus", "Mustang", "Bronco", "Capri", "Explorer", "F-150", "GT", "Kuga", "Puma", "Ranger", "Tourneo Connect", "Tourneo Courier", "Tourneo Custom", "Transit Connect", "Transit Custom", "Ka", "Cougar", "Ka+", "Probe", "Orion", "Escort", "Sierra", "Granada", "Otro" } },
            { "Abarth", new List<string> { "500", "595", "695", "Otro"} },
            { "Aiways", new List<string> { "U5", "U6", "Otro"} },
            { "AlfaRomeo", new List<string> { "33 Stradale", "Giulia", "Giulia SWB Zagato", "Junior", "Stelvio", "Tonale", "157", "Otro"} },
            { "AstonMartin", new List<string> { "DB12", "DBS", "DBX", "Valhalla", "Valkyrie", "Valour", "Vantage", "Otro"} },
            { "Audi", new List<string> { "A1", "A2", "A3", "A4", "A5", "A6", "A7", "A8", "Q2", "Q3", "Q4", "Q5", "Q6", "Q7", "Q8", "TT", "R8", "Otro"} },
            { "Bentley", new List<string> { "Bacalar", "Batur", "Bentayga", "Continental GT", "Flying Spur", "Otro"} },
            { "BMW", new List<string> { "i4", "i5", "i7", "iX", "iX1", "iX2", "iX3", "Serie 1", "Serie 2", "Serie 3", "Serie 4", "Serie 5", "Serie 6", "Serie 7", "Serie 8", "X1", "X2", "X3", "X4", "X5", "X6", "X7", "XM", "Z3", "Z4", "Z8", "M1", "Otro"} },
            { "Bugatti", new List<string> { "Mistral", "Veyron", "Chiron", "Otro"} },
            { "BYD", new List<string> { "Atto 3", "Dolphin", "Han", "Seal", "Seal U", "Sealion 7", "Tang", "Otro"} },
            { "Caterham", new List<string> { "Seven", "Otro"} },
            { "Citroen", new List<string> { "Ami", "Berlingo", "C2", "C3", "C3 Aircross","C4", "C4 X", "C5", "C5 Aircross", "C5 X", "C6", "C8", "SpaceTourer", "BX", "Xantia", "Otro"} },
            { "Cupra", new List<string> { "Ateca", "Born", "Formentor", "León", "Raval", "Tavascan", "Terramar","Otro"} },
            { "DR", new List<string> { "1.0", "3.0", "4.0", "5.0", "6.0", "7.0", "PK8", "Otro"} },
            { "DS", new List<string> { "3", "4", "5", "7", "9", "Otro"} },
            { "Ebro", new List<string> { "S700", "S800", "Otro"} },
            { "Ferrari", new List<string> { "12Cilindri", "296", "BR20", "Daytona", "F8", "F80", "KC23", "Portofino", "Purosangue", "Roma", "SF90", "458 Italia", "430", "Enzo", "Dino", "LaFerrari", "F40", "F50" ,"Otro"} },
            { "Fiat", new List<string> { "500", "500X", "500L", "600", "Doblo", "Panda", "Grande Panda", "Punto", "Tipo", "Ulysse", "Otro"} },
            { "Geely", new List<string> { "Galaxy E8", "Otro"} },
            { "Honda", new List<string> { "Civic", "CR-V", "e:Ny1", "HR-V", "Jazz", "ZR-V", "Otro"} },
            { "Hyundai", new List<string> { "Bayon", "i10", "i20", "i30", "Inster", "IONIQ 5", "IONIQ 6", "Kona", "Nexo", "Santa Fe", "Staria", "Tucson", "Otro"} },
            { "Isuzu", new List<string> { "D-MAX", "Otro"} },
            { "Jaecoo", new List<string> { "5", "7", "8", "Otro"} },
            { "Jaguar", new List<string> { "E-PACE", "F-PACE", "I-PACE", "Otro"} },
            { "Jeep", new List<string> { "Avenger", "Compass", "Grand Cherokee", "Recon", "Renegade", "Warngler", "Otro"} },
            { "Kia", new List<string> { "Ceed", "EV3", "EV5", "EV6", "EV9", "Niro", "Picanto", "Sorento", "Sportage", "Stinger", "Stonic", "XCeed", "Otro"} },
            { "Koenigsegg", new List<string> { "Gemera", "Jesko", "One", "Regera", "Agera", "Otro"} },
            { "KTM", new List<string> { "X-Bow", "Otro"} },
            { "Lamborghini", new List<string> { "Miura", "Countach", "Diablo", "Gallardo", "Murciélago", "Reventón", "Aventador", "Huracán", "Terzo Milenio", "Sesto Elemento", "Auténtica", "Invencible", "Revuelto", "Temerario", "Urus", "Urraco", "Otro"} },
            { "Lancia", new List<string> { "Ypsilon", "HF Integrale", "integrale", "037", "Thema", "Otro"} },
            { "LandRover", new List<string> { "Defender", "Discovery", "Freelander", "Otro"} },
            { "Lexus", new List<string> { "ES", "IS", "LBX", "LC", "LM", "LS", "NX", "RX", "RZ", "UX", "Otro"} },
            { "Lotus", new List<string> { "Eletre", "Emeya", "Emira", "Evija", "Exige", "Evora", "Otro"} },
            { "Lynk&Co", new List<string> { "01", "02", "Otro"} },
            { "Maserati", new List<string> { "Ghibli", "GranCabrio", "GranTurismo", "Grecale", "GT2", "Levante", "MC20", "Quattroporte", "Otro"} },
            { "Mazda", new List<string> { "CX-30", "CX-5", "CX-60", "CX-80", "Mazda2", "Mazda3", "MX-30", "MX-5", "RX7", "RX8", "Otro"} },
            { "McLaren", new List<string> { "Artura", "GTS", "750S", "765LT", "Super Series", "Elva", "Speedtail", "Senna", "W1", "Otro"} },
            { "Mercedes", new List<string> { "AMG GT", "AMG ONE", "Citan", "CLA", "Clase A", "Clase B", "Clase C", "Clase E", "Clase G", "GLC", "GLS", "Clase S", "Clase T", "Clase V", "CLE", "EQA", "EQB", "EQE", "EQS", "EQT", "EQV", "GLA", "GLB", "GLE", "SL", "Vito", "190", "Otro"} },
            { "MG", new List<string> { "Cyberster", "ES5", "HS", "Marvel R", "MG3", "MG4", "MG5", "ZS", "Otro"} },
            { "Mini", new List<string> { "MINI", "Aceman", "Countyman", "Cooper", "Otro"} },
            { "Mitsubishi", new List<string> { "ASX", "Colt", "Eclipse", "Eclipse Cross", "Outlander", "Space Star", "Montero", "Lancer Evo", "Otro"} },
            { "Morgan", new List<string> { "Plus", "Otro"} },
            { "Omoda", new List<string> { "5", "7", "Otro"} },
            { "Opel", new List<string> { "Astra", "Combo", "Corsa", "Frontera", "Grandland", "Mokka", "Rocks-e", "Zafira Life", "Zafira", "Kadett", "Otro"} },
            { "Peugeot", new List<string> { "2008", "208", "3008", "308", "408", "5008", "508", "Rifter", "Traveller", "205", "206", "306", "207", "307", "Otro"} },
            { "Polestar", new List<string> { "1", "2", "3", "4", "5", "6", "Otro"} },
            { "Porsche", new List<string> { "718", "911", "Cayenne", "Macan", "Panamera", "Taycan", "Otro"} },
            { "RangeRover", new List<string> { "Evoque", "Sport", "Velar", "Otro"} },
            { "Renault", new List<string> { "4", "5", "Arkana", "8", "Fuego", "19", "21", "Austral", "Captur", "Clio", "Esapce", "Kangoo", "Megane", "Rafale", "Scénic", "SpaceClass", "Symbioz", "Trafic", "Twizy", "Otro"} },
            { "Rimac", new List<string> { "Nevera", "Otro"} },
            { "RollsRoyce", new List<string> { "Cullinan", "Ghost", "La Rose Noire Droptail", "Phantom", "Spectre", "Wraith", "Otro"} },
            { "Seat", new List<string> { "Arona", "Ateca", "Ibiza", "León", "Tarraco", "Toledo", "Málaga", "Alhambra", "Otro"} },
            { "Skoda", new List<string> { "Elroq", "Enyaq", "Fabia", "Kamiq", "Karoq", "Kodiaq", "Octavia", "Scala", "Superb", "Otro"} },
            { "Smart", new List<string> { "#1", "#3", "#5", "Otro"} },
            { "SsangYong", new List<string> { "Actyon", "Actyon Sports", "Korando", "Kyron", "Musso", "Rexton", "RExton II", "Rodius", "Sports Pick Up", "Tivoli", "Torres", "XLV", "Otro"} },
            { "Subaru", new List<string> { "BRZ", "Crosstrek", "Impreza", "Forester", "Outback", "Solterra", "Otro"} },
            { "Suzuki", new List<string> { "Across", "Ignis", "S-Cross", "Swace", "Swift", "Vitara", "Jimny", "Otro"} },
            { "Tesla", new List<string> { "Cybertruck", "Model 3", "Model S", "Model X", "Model Y", "Otro"} },
            { "Volkswagen", new List<string> { "Amarok", "Caddy", "Golf", "Grand California", "ID. Buzz", "ID.3", "ID.4", "ID.5", "ID.7", "Passat", "Polo", "T-cross", "T-Roc", "Passat Cc", "Arteon", "T6", "T7", "Taigo", "Tayron", "Tiguan", "Tourageg", "Touran", "Otro"} },
            { "Volvo", new List<string> { "EC40", "EM90", "EX30", "EX40", "EX90", "V60", "V90", "XC40", "XC60", "XC90", "Otro"} },
            { "Chevrolet", new List<string> { "Aveo", "Camaro", "Captiva", "Cruze", "Spark", "Corvette", "Volt", "Malibu", "Trax", "Otro"} },
            { "Lada", new List<string> { "4x4", "Priora", "Otro"} },
            { "Infiniti", new List<string> { "Q30", "Q50", "Q60", "Q70", "QX30", "QX50", "QX70", "Otro"} },
            { "Lincoln", new List<string> { "Navigator", "Corsair", "Aviator", "Nautilus", "Otro"} },
            { "Buick", new List<string> { "Enclave", "Encore GX", "Envision", "Envista", "Roadmaster", "Skylark", "LeSabre", "Riviera", "Century", "Otro"} },
            { "Cadillac", new List<string> { "CT4", "CT5", "XT4", "XT5", "XT6", "Escalade", "Lyriq", "Celestiq", "Century", "Series 62", "Eldorado", "Fleetwood", "DeVille", "Sixty Special", "LaSalle", "Brougham", "CTS-V", "V16", "Allante", "Otro"} },
            { "GMC", new List<string> { "Sierra 1500", "Sierra HD", "Canyon", "Terrain", "Acadia", "Yukon", "Hummer EV", "Sierra EV", "Otro"} },
            { "Chrysler", new List<string> { "300", "Pacifica", "Voyager", "PT Cruiser", "Sebring", "Crossfire", "Otro"} },
            { "Dodge", new List<string> { "Challenger", "Charger", "Durango", "Hornet", "Viper", "Neon", "Avenger", "Otro"} },
            { "Vauxhall", new List<string> { "Corsa", "Astra", "Insignia", "Mokka", "Grandland", "Crossland", "Combo Life", "Vivaro Life", "Combo Cargo", "Vivaro", "Movano", "Otro"} },
            { "Acura", new List<string> { "Integra", "TLX", "RDX", "MDX", "ZDX", "TLX Type S", "MDX Type S", "NSX", "Otro"} },
            { "Genesis", new List<string> { "G70", "G80", "G90", "GV60", "GV70", "GV80", "Electrified G80", "Electrified GV70", "Otro"} },
            { "Tata", new List<string> { "Tiago", "Tigor", "Altroz", "Nexon", "Harrier", "Safari", "Nexon EV", "Tigor EV", "Tiago EV", "Ace", "Intra", "Yodha", "Otro"} },
            { "Daihatsu", new List<string> { "Cuore/Mira", "Charade", "Sirion", "Terios", "Copen", "Rocky", "Boon", "Move", "Taft", "Otro"} },
            { "Otros", new List<string> { "Otro"} },
        };

        _motoresPorModelo = new Dictionary<string, Dictionary<string, List<string>>>
        {
           { 
            "A110", new Dictionary<string, List<string>>()
            {
                { "Gasolina", new List<string> { "1.8L", "956cc", "1.1L", "1.3L", "1.6L" } }
            }
            },
            {
                "A290", new Dictionary<string, List<string>>()
                {
                    { "Eléctrico", new List<string> { "6AM" } }
                }
            },
            {
                "A310", new Dictionary<string, List<string>>()
                {
                    { "Gasolina", new List<string> { "1.6L", "V6 PRV 2.7L" } }
                }
            },
                    {
                "A610", new Dictionary<string, List<string>>()
                {
                    { "Gasolina", new List<string> { "V6 PRV 3.0L" } }
                }
            },
            {
                "A106", new Dictionary<string, List<string>>()
                {
                    { "Gasolina", new List<string> { "Ventoux 747cc" } }
                }
            },
            {
                "A108", new Dictionary<string, List<string>>()
                {
                    { "Gasolina", new List<string> { "Ventoux 845cc", "Ventoux 904cc", "Sierra 998cc", "Sierra 1.1L" } }
                }
            },
                    {
                "GTA", new Dictionary<string, List<string>>()
                {
                    { "Gasolina", new List<string> { "PRV V6 2.8L", "PRV V6 Turbo 2.5L", } }
                }
            },
            {
                "Duster", new Dictionary<string, List<string>>()
                {
                    { "Gasolina", new List<string> { "1.6L", "2.0L", "1.0 TCe", "1.3 TCe" } },
                    { "Diesel", new List<string> { "1.5 dCi", "1.5 Blue dCi" } },
                    { "Híbrido", new List<string> { "1.6L Híbrido" } },
                    { "GLP", new List<string> { "1.0 ECO-G" } },

                }
            },
            {
                "Logan", new Dictionary<string, List<string>>()
                {
                    { "Gasolina", new List<string> { "1.4 MPI", "1.6 MPI", "1.6 16V", "1.2 16V", "0.9 TCe", "1.0 SCe", "1.0 TCe" } },
                    { "Diesel", new List<string> { "1.5 dCi", "1.5 Blue dCi" } },
                    { "GLP", new List<string> { "1.2 16V LPG", "1.0 ECO-G" } },

                }
            },
            {
                "Lodgy", new Dictionary<string, List<string>>()
                {
                    { "Gasolina", new List<string> { "1.6 MPI", "1.2 TCe", "1.3 TCe" } },
                    { "Diesel", new List<string> { "1.5 dCi", "1.5 Blue dCi" } },
                    { "GLP", new List<string> { "1.2 16V GLP" } },

                }
            },
            {
                "Dokker", new Dictionary<string, List<string>>()
                {
                    { "Gasolina", new List<string> { "1.6 MPI", "1.2 TCe", "1.3 TCe" } },
                    { "Diesel", new List<string> { "1.5 dCi", "1.5 Blue dCi" } },
                    { "GLP", new List<string> { "1.2 16V GLP" } },

                }
            },
            {
                "Sandero", new Dictionary<string, List<string>>()
                {
                    { "Gasolina", new List<string> { "1.2 16V", "1.4 MPI", "1.6 MPI", "1.6 16V", "1.0 SCe", "0.9 TCe", "1.0 TCe" } },
                    { "Diesel", new List<string> { "1.5 dCi", "1.5 Blue dCi" } },
                    { "GLP", new List<string> { "1.2 16V LPG", "1.0 ECO-G" } },

                }
            },
                    {
                "Jogger", new Dictionary<string, List<string>>()
                {
                    { "Gasolina", new List<string> { "1.0 TCe 110" } },
                    { "Híbrido", new List<string> { "1.6 Hybrid 140" } },
                    { "GLP", new List<string> { "1.0 ECO-G 100" } },

                }
            },
                    {
                "Spring", new Dictionary<string, List<string>>()
                {
                    { "Eléctrico", new List<string> { "Electric 45", "Electric 65" } },

                }
            },
            {
                "Qashqai", new Dictionary<string, List<string>>()
                {
                    { "Gasolina", new List<string> { "1.3 Gasolina", "1.5 Turbo Gasolina" } },
                    { "Eléctrico", new List<string> { "E-Power Motor" } },
                    { "Diesel", new List<string> { "2.0 Diesel" } }
                }
            },
            {
                "Corolla", new Dictionary<string, List<string>>()
                {
                    { "Híbrido", new List<string> { "1.8 Hybrid", "2.0 Hybrid" } },
                    { "Gasolina", new List<string> { "1.6 Gasolina" } }
                }
            },
            {
                "Mustang", new Dictionary<string, List<string>>()
                {
                    { "Gasolina", new List<string> { "2.3 Ecoboost", "5.0 V8" } },
                    { "Eléctrico", new List<string> { "Mach-E Electric" } }
                }
            },
            {
                "Civic", new Dictionary<string, List<string>>()
                {
                    { "Gasolina", new List<string> { "1.5 Turbo", "2.0 NA" } },
                    { "Diesel", new List<string> { "1.6 Diesel" } },
                    { "Híbrido", new List<string> { "1.5 Hybrid" } }
                }
            },
            { 
                "Otro", new Dictionary<string, List<string>>()
                {
                    { "Gasolina", new List<string> { "Motor General" } },
                    { "Diesel", new List<string> { "Motor Diesel" } },
                    { "Eléctrico", new List<string> { "Motor Eléctrico" } },
                    { "Híbrido", new List<string> { "Motor Híbrido" } },
                    { "GLP", new List<string> { "Motor GLP" } },

                }
            }
        };
    }

    public Task<List<string>> ObtenerModelos(string fabricante)
    {
        var modelos = _modelosPorFabricante.ContainsKey(fabricante) ? _modelosPorFabricante[fabricante] : new List<string>();
        return Task.FromResult(modelos);
    }

    public async Task<List<string>> ObtenerMotorizaciones(string modelo, string? tipoCombustible)
    {
        await Task.Delay(10); // Simula retraso

        if (string.IsNullOrEmpty(tipoCombustible))
        {
            // Si no se especifica tipo de combustible, devuelve todas las motorizaciones disponibles
            return _motoresPorModelo.ContainsKey(modelo)
                ? _motoresPorModelo[modelo].Keys.ToList()
                : new List<string>();
        }

        // Devuelve los motores para el modelo y tipo de combustible especificados
        return _motoresPorModelo.ContainsKey(modelo) && _motoresPorModelo[modelo].ContainsKey(tipoCombustible)
            ? _motoresPorModelo[modelo][tipoCombustible]
            : new List<string>();
    }

}

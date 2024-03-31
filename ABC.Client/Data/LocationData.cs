namespace ABC.Client.Data;
public partial class LocationData
{
	public static List<string> Provinces = new List<string> { "Rizal", "Metro Manila", "Manila" };

	public static Dictionary<string, List<string>> Cities = new Dictionary<string, List<string>>
		{
			{ "Rizal", new List<string>
				{
					"Angono",
					"Antipolo",
					"Baras",
					"Binangonan",
					"Cainta",
					"Cardona",
					"Jalajala",
					"Morong",
					"Pililla",
					"Rodriguez",
					"San Mateo",
					"Tanay",
					"Taytay",
					"Teresa"
				}
			},

			{ "Metro Manila", new List<string>
				{
					"City of Manila",
					"Caloocan",
					"Las Piñas",
					"Makati",
					"Malabon",
					"Mandaluyong",
					"Marikina",
					"Muntinlupa",
					"Navotas",
					"Parañaque",
					"Pasay",
					"Pasig",
					"Quezon City",
					"San Juan",
					"Taguig",
					"Valenzuela"
				}
			},

			{ "Manila", new List<string>
				{
					"Binondo",
					"Ermita",
					"Intramuros",
					"Malate",
					"Paco",
					"Pandacan",
					"Port Area",
					"Quiapo",
					"Sampaloc",
					"San Andres",
					"San Miguel",
					"San Nicolas",
					"Santa Ana",
					"Santa Cruz",
					"Santa Mesa",
					"Tondo"
				}
			}

		};
}


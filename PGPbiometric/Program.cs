using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PGPbiometric
{
    class Program
    {
        public static Dictionary<byte, Tuple<string, string>> WordDictionary = new Dictionary<byte, Tuple<string, string>>()
        {
            {0x00, new Tuple<string, string>("aardvark", "adroitness")},
            {0x01, new Tuple<string, string>("absurd", "adviser")},
            {0x02, new Tuple<string, string>("accrue", "aftermath")},
            {0x03, new Tuple<string, string>("acme", "aggregate")},
            {0x04, new Tuple<string, string>("adrift", "alkali")},
            {0x05, new Tuple<string, string>("adult", "almighty")},
            {0x06, new Tuple<string, string>("afflict", "amulet")},
            {0x07, new Tuple<string, string>("ahead", "amusement")},
            {0x08, new Tuple<string, string>("aimless", "antenna")},
            {0x09, new Tuple<string, string>("Algol", "applicant")},
            {0x0A, new Tuple<string, string>("allow", "Apollo")},
            {0x0B, new Tuple<string, string>("alone", "armistice")},
            {0x0C, new Tuple<string, string>("ammo", "article")},
            {0x0D, new Tuple<string, string>("ancient", "asteroid")},
            {0x0E, new Tuple<string, string>("apple", "Atlantic")},
            {0x0F, new Tuple<string, string>("artist", "atmosphere")},
            {0x10, new Tuple<string, string>("assume", "autopsy")},
            {0x11, new Tuple<string, string>("Athens", "Babylon")},
            {0x12, new Tuple<string, string>("atlas", "backwater")},
            {0x13, new Tuple<string, string>("Aztec", "barbecue")},
            {0x14, new Tuple<string, string>("baboon", "belowground")},
            {0x15, new Tuple<string, string>("backfield", "bifocals")},
            {0x16, new Tuple<string, string>("backward", "bodyguard")},
            {0x17, new Tuple<string, string>("banjo", "bookseller")},
            {0x18, new Tuple<string, string>("beaming", "borderline")},
            {0x19, new Tuple<string, string>("bedlamp", "bottomless")},
            {0x1A, new Tuple<string, string>("beehive", "Bradbury")},
            {0x1B, new Tuple<string, string>("beeswax", "bravado")},
            {0x1C, new Tuple<string, string>("befriend", "Brazilian")},
            {0x1D, new Tuple<string, string>("Belfast", "breakaway")},
            {0x1E, new Tuple<string, string>("berserk", "Burlington")},
            {0x1F, new Tuple<string, string>("billiard", "businessman")},
            {0x20, new Tuple<string, string>("bison", "butterfat")},
            {0x21, new Tuple<string, string>("blackjack", "Camelot")},
            {0x22, new Tuple<string, string>("blockade", "candidate")},
            {0x23, new Tuple<string, string>("blowtorch", "cannonball")},
            {0x24, new Tuple<string, string>("bluebird", "Capricorn")},
            {0x25, new Tuple<string, string>("bombast", "caravan")},
            {0x26, new Tuple<string, string>("bookshelf", "caretaker")},
            {0x27, new Tuple<string, string>("brackish", "celebrate")},
            {0x28, new Tuple<string, string>("breadline", "cellulose")},
            {0x29, new Tuple<string, string>("breakup", "certify")},
            {0x2A, new Tuple<string, string>("brickyard", "chambermaid")},
            {0x2B, new Tuple<string, string>("briefcase", "Cherokee")},
            {0x2C, new Tuple<string, string>("Burbank", "Chicago")},
            {0x2D, new Tuple<string, string>("button", "clergyman")},
            {0x2E, new Tuple<string, string>("buzzard", "coherence")},
            {0x2F, new Tuple<string, string>("cement", "combustion")},
            {0x30, new Tuple<string, string>("chairlift", "commando")},
            {0x31, new Tuple<string, string>("chatter", "company")},
            {0x32, new Tuple<string, string>("checkup", "component")},
            {0x33, new Tuple<string, string>("chisel", "concurrent")},
            {0x34, new Tuple<string, string>("choking", "confidence")},
            {0x35, new Tuple<string, string>("chopper", "conformist")},
            {0x36, new Tuple<string, string>("Christmas", "congregate")},
            {0x37, new Tuple<string, string>("clamshell", "consensus")},
            {0x38, new Tuple<string, string>("classic", "consulting")},
            {0x39, new Tuple<string, string>("classroom", "corporate")},
            {0x3A, new Tuple<string, string>("cleanup", "corrosion")},
            {0x3B, new Tuple<string, string>("clockwork", "councilman")},
            {0x3C, new Tuple<string, string>("cobra", "crossover")},
            {0x3D, new Tuple<string, string>("commence", "crucifix")},
            {0x3E, new Tuple<string, string>("concert", "cumbersome")},
            {0x3F, new Tuple<string, string>("cowbell", "customer")},
            {0x40, new Tuple<string, string>("crackdown", "Dakota")},
            {0x41, new Tuple<string, string>("cranky", "decadence")},
            {0x42, new Tuple<string, string>("crowfoot", "December")},
            {0x43, new Tuple<string, string>("crucial", "decimal")},
            {0x44, new Tuple<string, string>("crumpled", "designing")},
            {0x45, new Tuple<string, string>("crusade", "detector")},
            {0x46, new Tuple<string, string>("cubic", "detergent")},
            {0x47, new Tuple<string, string>("dashboard", "determine")},
            {0x48, new Tuple<string, string>("deadbolt", "dictator")},
            {0x49, new Tuple<string, string>("deckhand", "dinosaur")},
            {0x4A, new Tuple<string, string>("dogsled", "direction")},
            {0x4B, new Tuple<string, string>("dragnet", "disable")},
            {0x4C, new Tuple<string, string>("drainage", "disbelief")},
            {0x4D, new Tuple<string, string>("dreadful", "disruptive")},
            {0x4E, new Tuple<string, string>("drifter", "distortion")},
            {0x4F, new Tuple<string, string>("dropper", "document")},
            {0x50, new Tuple<string, string>("drumbeat", "embezzle")},
            {0x51, new Tuple<string, string>("drunken", "enchanting")},
            {0x52, new Tuple<string, string>("Dupont", "enrollment")},
            {0x53, new Tuple<string, string>("dwelling", "enterprise")},
            {0x54, new Tuple<string, string>("eating", "equation")},
            {0x55, new Tuple<string, string>("edict", "equipment")},
            {0x56, new Tuple<string, string>("egghead", "escapade")},
            {0x57, new Tuple<string, string>("eightball", "Eskimo")},
            {0x58, new Tuple<string, string>("endorse", "everyday")},
            {0x59, new Tuple<string, string>("endow", "examine")},
            {0x5A, new Tuple<string, string>("enlist", "existence")},
            {0x5B, new Tuple<string, string>("erase", "exodus")},
            {0x5C, new Tuple<string, string>("escape", "fascinate")},
            {0x5D, new Tuple<string, string>("exceed", "filament")},
            {0x5E, new Tuple<string, string>("eyeglass", "finicky")},
            {0x5F, new Tuple<string, string>("eyetooth", "forever")},
            {0x60, new Tuple<string, string>("facial", "fortitude")},
            {0x61, new Tuple<string, string>("fallout", "frequency")},
            {0x62, new Tuple<string, string>("flagpole", "gadgetry")},
            {0x63, new Tuple<string, string>("flatfoot", "Galveston")},
            {0x64, new Tuple<string, string>("flytrap", "getaway")},
            {0x65, new Tuple<string, string>("fracture", "glossary")},
            {0x66, new Tuple<string, string>("framework", "gossamer")},
            {0x67, new Tuple<string, string>("freedom", "graduate")},
            {0x68, new Tuple<string, string>("frighten", "gravity")},
            {0x69, new Tuple<string, string>("gazelle", "guitarist")},
            {0x6A, new Tuple<string, string>("Geiger", "hamburger")},
            {0x6B, new Tuple<string, string>("glitter", "Hamilton")},
            {0x6C, new Tuple<string, string>("glucose", "handiwork")},
            {0x6D, new Tuple<string, string>("goggles", "hazardous")},
            {0x6E, new Tuple<string, string>("goldfish", "headwaters")},
            {0x6F, new Tuple<string, string>("gremlin", "hemisphere")},
            {0x70, new Tuple<string, string>("guidance", "hesitate")},
            {0x71, new Tuple<string, string>("hamlet", "hideaway")},
            {0x72, new Tuple<string, string>("highchair", "holiness")},
            {0x73, new Tuple<string, string>("hockey", "hurricane")},
            {0x74, new Tuple<string, string>("indoors", "hydraulic")},
            {0x75, new Tuple<string, string>("indulge", "impartial")},
            {0x76, new Tuple<string, string>("inverse", "impetus")},
            {0x77, new Tuple<string, string>("involve", "inception")},
            {0x78, new Tuple<string, string>("island", "indigo")},
            {0x79, new Tuple<string, string>("jawbone", "inertia")},
            {0x7A, new Tuple<string, string>("keyboard", "infancy")},
            {0x7B, new Tuple<string, string>("kickoff", "inferno")},
            {0x7C, new Tuple<string, string>("kiwi", "informant")},
            {0x7D, new Tuple<string, string>("klaxon", "insincere")},
            {0x7E, new Tuple<string, string>("locale", "insurgent")},
            {0x7F, new Tuple<string, string>("lockup", "integrate")},
            {0x80, new Tuple<string, string>("merit", "intention")},
            {0x81, new Tuple<string, string>("minnow", "inventive")},
            {0x82, new Tuple<string, string>("miser", "Istanbul")},
            {0x83, new Tuple<string, string>("Mohawk", "Jamaica")},
            {0x84, new Tuple<string, string>("mural", "Jupiter")},
            {0x85, new Tuple<string, string>("music", "leprosy")},
            {0x86, new Tuple<string, string>("necklace", "letterhead")},
            {0x87, new Tuple<string, string>("Neptune", "liberty")},
            {0x88, new Tuple<string, string>("newborn", "maritime")},
            {0x89, new Tuple<string, string>("nightbird", "matchmaker")},
            {0x8A, new Tuple<string, string>("Oakland", "maverick")},
            {0x8B, new Tuple<string, string>("obtuse", "Medusa")},
            {0x8C, new Tuple<string, string>("offload", "megaton")},
            {0x8D, new Tuple<string, string>("optic", "microscope")},
            {0x8E, new Tuple<string, string>("orca", "microwave")},
            {0x8F, new Tuple<string, string>("payday", "midsummer")},
            {0x90, new Tuple<string, string>("peachy", "millionaire")},
            {0x91, new Tuple<string, string>("pheasant", "miracle")},
            {0x92, new Tuple<string, string>("physique", "misnomer")},
            {0x93, new Tuple<string, string>("playhouse", "molasses")},
            {0x94, new Tuple<string, string>("Pluto", "molecule")},
            {0x95, new Tuple<string, string>("preclude", "Montana")},
            {0x96, new Tuple<string, string>("prefer", "monument")},
            {0x97, new Tuple<string, string>("preshrunk", "mosquito")},
            {0x98, new Tuple<string, string>("printer", "narrative")},
            {0x99, new Tuple<string, string>("prowler", "nebula")},
            {0x9A, new Tuple<string, string>("pupil", "newsletter")},
            {0x9B, new Tuple<string, string>("puppy", "Norwegian")},
            {0x9C, new Tuple<string, string>("python", "October")},
            {0x9D, new Tuple<string, string>("quadrant", "Ohio")},
            {0x9E, new Tuple<string, string>("quiver", "onlooker")},
            {0x9F, new Tuple<string, string>("quota", "opulent")},
            {0xA0, new Tuple<string, string>("ragtime", "Orlando")},
            {0xA1, new Tuple<string, string>("ratchet", "outfielder")},
            {0xA2, new Tuple<string, string>("rebirth", "Pacific")},
            {0xA3, new Tuple<string, string>("reform", "pandemic")},
            {0xA4, new Tuple<string, string>("regain", "Pandora")},
            {0xA5, new Tuple<string, string>("reindeer", "paperweight")},
            {0xA6, new Tuple<string, string>("rematch", "paragon")},
            {0xA7, new Tuple<string, string>("repay", "paragraph")},
            {0xA8, new Tuple<string, string>("retouch", "paramount")},
            {0xA9, new Tuple<string, string>("revenge", "passenger")},
            {0xAA, new Tuple<string, string>("reward", "pedigree")},
            {0xAB, new Tuple<string, string>("rhythm", "Pegasus")},
            {0xAC, new Tuple<string, string>("ribcage", "penetrate")},
            {0xAD, new Tuple<string, string>("ringbolt", "perceptive")},
            {0xAE, new Tuple<string, string>("robust", "performance")},
            {0xAF, new Tuple<string, string>("rocker", "pharmacy")},
            {0xB0, new Tuple<string, string>("ruffled", "phonetic")},
            {0xB1, new Tuple<string, string>("sailboat", "photograph")},
            {0xB2, new Tuple<string, string>("sawdust", "pioneer")},
            {0xB3, new Tuple<string, string>("scallion", "pocketful")},
            {0xB4, new Tuple<string, string>("scenic", "politeness")},
            {0xB5, new Tuple<string, string>("scorecard", "positive")},
            {0xB6, new Tuple<string, string>("Scotland", "potato")},
            {0xB7, new Tuple<string, string>("seabird", "processor")},
            {0xB8, new Tuple<string, string>("select", "provincial")},
            {0xB9, new Tuple<string, string>("sentence", "proximate")},
            {0xBA, new Tuple<string, string>("shadow", "puberty")},
            {0xBB, new Tuple<string, string>("shamrock", "publisher")},
            {0xBC, new Tuple<string, string>("showgirl", "pyramid")},
            {0xBD, new Tuple<string, string>("skullcap", "quantity")},
            {0xBE, new Tuple<string, string>("skydive", "racketeer")},
            {0xBF, new Tuple<string, string>("slingshot", "rebellion")},
            {0xC0, new Tuple<string, string>("slowdown", "recipe")},
            {0xC1, new Tuple<string, string>("snapline", "recover")},
            {0xC2, new Tuple<string, string>("snapshot", "repellent")},
            {0xC3, new Tuple<string, string>("snowcap", "replica")},
            {0xC4, new Tuple<string, string>("snowslide", "reproduce")},
            {0xC5, new Tuple<string, string>("solo", "resistor")},
            {0xC6, new Tuple<string, string>("southward", "responsive")},
            {0xC7, new Tuple<string, string>("soybean", "retraction")},
            {0xC8, new Tuple<string, string>("spaniel", "retrieval")},
            {0xC9, new Tuple<string, string>("spearhead", "retrospect")},
            {0xCA, new Tuple<string, string>("spellbind", "revenue")},
            {0xCB, new Tuple<string, string>("spheroid", "revival")},
            {0xCC, new Tuple<string, string>("spigot", "revolver")},
            {0xCD, new Tuple<string, string>("spindle", "sandalwood")},
            {0xCE, new Tuple<string, string>("spyglass", "sardonic")},
            {0xCF, new Tuple<string, string>("stagehand", "Saturday")},
            {0xD0, new Tuple<string, string>("stagnate", "savagery")},
            {0xD1, new Tuple<string, string>("stairway", "scavenger")},
            {0xD2, new Tuple<string, string>("standard", "sensation")},
            {0xD3, new Tuple<string, string>("stapler", "sociable")},
            {0xD4, new Tuple<string, string>("steamship", "souvenir")},
            {0xD5, new Tuple<string, string>("sterling", "specialist")},
            {0xD6, new Tuple<string, string>("stockman", "speculate")},
            {0xD7, new Tuple<string, string>("stopwatch", "stethoscope")},
            {0xD8, new Tuple<string, string>("stormy", "stupendous")},
            {0xD9, new Tuple<string, string>("sugar", "supportive")},
            {0xDA, new Tuple<string, string>("surmount", "surrender")},
            {0xDB, new Tuple<string, string>("suspense", "suspicious")},
            {0xDC, new Tuple<string, string>("sweatband", "sympathy")},
            {0xDD, new Tuple<string, string>("swelter", "tambourine")},
            {0xDE, new Tuple<string, string>("tactics", "telephone")},
            {0xDF, new Tuple<string, string>("talon", "therapist")},
            {0xE0, new Tuple<string, string>("tapeworm", "tobacco")},
            {0xE1, new Tuple<string, string>("tempest", "tolerance")},
            {0xE2, new Tuple<string, string>("tiger", "tomorrow")},
            {0xE3, new Tuple<string, string>("tissue", "torpedo")},
            {0xE4, new Tuple<string, string>("tonic", "tradition")},
            {0xE5, new Tuple<string, string>("topmost", "travesty")},
            {0xE6, new Tuple<string, string>("tracker", "trombonist")},
            {0xE7, new Tuple<string, string>("transit", "truncated")},
            {0xE8, new Tuple<string, string>("trauma", "typewriter")},
            {0xE9, new Tuple<string, string>("treadmill", "ultimate")},
            {0xEA, new Tuple<string, string>("Trojan", "undaunted")},
            {0xEB, new Tuple<string, string>("trouble", "underfoot")},
            {0xEC, new Tuple<string, string>("tumor", "unicorn")},
            {0xED, new Tuple<string, string>("tunnel", "unify")},
            {0xEE, new Tuple<string, string>("tycoon", "universe")},
            {0xEF, new Tuple<string, string>("uncut", "unravel")},
            {0xF0, new Tuple<string, string>("unearth", "upcoming")},
            {0xF1, new Tuple<string, string>("unwind", "vacancy")},
            {0xF2, new Tuple<string, string>("uproot", "vagabond")},
            {0xF3, new Tuple<string, string>("upset", "vertigo")},
            {0xF4, new Tuple<string, string>("upshot", "Virginia")},
            {0xF5, new Tuple<string, string>("vapor", "visitor")},
            {0xF6, new Tuple<string, string>("village", "vocalist")},
            {0xF7, new Tuple<string, string>("virus", "voyager")},
            {0xF8, new Tuple<string, string>("Vulcan", "warranty")},
            {0xF9, new Tuple<string, string>("waffle", "Waterloo")},
            {0xFA, new Tuple<string, string>("wallet", "whimsical")},
            {0xFB, new Tuple<string, string>("watchword", "Wichita")},
            {0xFC, new Tuple<string, string>("wayside", "Wilmington")},
            {0xFD, new Tuple<string, string>("willow", "Wyoming")},
            {0xFE, new Tuple<string, string>("woodlark", "yesteryear")},
            {0xFF, new Tuple<string, string>("Zulu", "Yucatan")}
        };
        static void Main(string[] args)
        {
            Stream stdIn = Console.OpenStandardInput();
            Stream stdOut = Console.OpenStandardOutput();
            Stream fileIn = new MemoryStream();
            Stream inputStream = new MemoryStream();

            if (args.Length == 1)
            {
                try
                {
                    fileIn = File.Open(args[0], FileMode.Open);
                }
                catch (FileNotFoundException e)
                {
                    if (e != null)
                    {
                        Console.Error.WriteLine("The specified file was not found.");
                        Console.Error.WriteLine("Please either use stdIn or specify the path to a binary file to encode.");
                        return;
                    }
                }
                inputStream = fileIn;
            }
            else if (args.Length == 0)
            {
                try
                {
                    bool tmp = Console.KeyAvailable;
                    Console.Error.WriteLine("Invalid command line arguments or no input detected.");
                    Console.Error.WriteLine("Please either use stdIn or specify the path to a binary file to encode.");
                    return;
                }
                catch (InvalidOperationException e)
                {
                    if (e != null)
                    {
                        //Do nothing.
                    }
                }
                inputStream = stdIn;
            }
            
            byte[] buffer = new byte[1];
            //byte[] debugInput = new byte[] {0x7f, 0x7f, 0x34, 0x90, 0x1e, 0x34, 0x5a, 0x9b};
            //inputStream = new MemoryStream(debugInput);
            int bytes;
            bool oddByte = false;
            bool firstByte = true;
            while ((bytes = inputStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                string biometricByte = string.Empty;
                if (firstByte != true)
                {
                    biometricByte = string.Concat(biometricByte, " ");                    
                }
                else
                {
                    firstByte = false;
                }
                Tuple<string, string> biometricTuple = WordDictionary.Where(x => x.Key == buffer[0]).First().Value;
                string biometricWord = string.Empty;
                if (oddByte == false)
                {
                    biometricWord = biometricTuple.Item1;
                }
                else
                {
                    biometricWord = biometricTuple.Item2;
                }
                oddByte = !oddByte;
                biometricByte = string.Concat(biometricByte, biometricWord);
                byte[] biometricByteArray = Encoding.UTF8.GetBytes(biometricByte);
                stdOut.Write(biometricByteArray, 0, biometricByteArray.Length);
            }
        }
    }
}

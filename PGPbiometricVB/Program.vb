Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace PGPbiometric
    Class Program
        Public Shared WordDictionary As New Dictionary(Of Byte, Tuple(Of String, String))() From { _
            {&H0, New Tuple(Of String, String)("aardvark", "adroitness")}, _
            {&H1, New Tuple(Of String, String)("absurd", "adviser")}, _
            {&H2, New Tuple(Of String, String)("accrue", "aftermath")}, _
            {&H3, New Tuple(Of String, String)("acme", "aggregate")}, _
            {&H4, New Tuple(Of String, String)("adrift", "alkali")},
            {&H5, New Tuple(Of String, String)("adult", "almighty")}, _
            {&H6, New Tuple(Of String, String)("afflict", "amulet")}, _
            {&H7, New Tuple(Of String, String)("ahead", "amusement")}, _
            {&H8, New Tuple(Of String, String)("aimless", "antenna")}, _
            {&H9, New Tuple(Of String, String)("Algol", "applicant")}, _
            {&HA, New Tuple(Of String, String)("allow", "Apollo")}, _
            {&HB, New Tuple(Of String, String)("alone", "armistice")}, _
            {&HC, New Tuple(Of String, String)("ammo", "article")}, _
            {&HD, New Tuple(Of String, String)("ancient", "asteroid")}, _
            {&HE, New Tuple(Of String, String)("apple", "Atlantic")}, _
            {&HF, New Tuple(Of String, String)("artist", "atmosphere")}, _
            {&H10, New Tuple(Of String, String)("assume", "autopsy")}, _
            {&H11, New Tuple(Of String, String)("Athens", "Babylon")}, _
            {&H12, New Tuple(Of String, String)("atlas", "backwater")}, _
            {&H13, New Tuple(Of String, String)("Aztec", "barbecue")}, _
            {&H14, New Tuple(Of String, String)("baboon", "belowground")}, _
            {&H15, New Tuple(Of String, String)("backfield", "bifocals")}, _
            {&H16, New Tuple(Of String, String)("backward", "bodyguard")}, _
            {&H17, New Tuple(Of String, String)("banjo", "bookseller")}, _
            {&H18, New Tuple(Of String, String)("beaming", "borderline")}, _
            {&H19, New Tuple(Of String, String)("bedlamp", "bottomless")}, _
            {&H1A, New Tuple(Of String, String)("beehive", "Bradbury")}, _
            {&H1B, New Tuple(Of String, String)("beeswax", "bravado")}, _
            {&H1C, New Tuple(Of String, String)("befriend", "Brazilian")}, _
            {&H1D, New Tuple(Of String, String)("Belfast", "breakaway")}, _
            {&H1E, New Tuple(Of String, String)("berserk", "Burlington")}, _
            {&H1F, New Tuple(Of String, String)("billiard", "businessman")}, _
            {&H20, New Tuple(Of String, String)("bison", "butterfat")}, _
            {&H21, New Tuple(Of String, String)("blackjack", "Camelot")}, _
            {&H22, New Tuple(Of String, String)("blockade", "candidate")}, _
            {&H23, New Tuple(Of String, String)("blowtorch", "cannonball")}, _
            {&H24, New Tuple(Of String, String)("bluebird", "Capricorn")}, _
            {&H25, New Tuple(Of String, String)("bombast", "caravan")}, _
            {&H26, New Tuple(Of String, String)("bookshelf", "caretaker")}, _
            {&H27, New Tuple(Of String, String)("brackish", "celebrate")}, _
            {&H28, New Tuple(Of String, String)("breadline", "cellulose")}, _
            {&H29, New Tuple(Of String, String)("breakup", "certify")}, _
            {&H2A, New Tuple(Of String, String)("brickyard", "chambermaid")}, _
            {&H2B, New Tuple(Of String, String)("briefcase", "Cherokee")}, _
            {&H2C, New Tuple(Of String, String)("Burbank", "Chicago")}, _
            {&H2D, New Tuple(Of String, String)("button", "clergyman")}, _
            {&H2E, New Tuple(Of String, String)("buzzard", "coherence")}, _
            {&H2F, New Tuple(Of String, String)("cement", "combustion")}, _
            {&H30, New Tuple(Of String, String)("chairlift", "commando")}, _
            {&H31, New Tuple(Of String, String)("chatter", "company")}, _
            {&H32, New Tuple(Of String, String)("checkup", "component")}, _
            {&H33, New Tuple(Of String, String)("chisel", "concurrent")}, _
            {&H34, New Tuple(Of String, String)("choking", "confidence")}, _
            {&H35, New Tuple(Of String, String)("chopper", "conformist")}, _
            {&H36, New Tuple(Of String, String)("Christmas", "congregate")}, _
            {&H37, New Tuple(Of String, String)("clamshell", "consensus")}, _
            {&H38, New Tuple(Of String, String)("classic", "consulting")}, _
            {&H39, New Tuple(Of String, String)("classroom", "corporate")}, _
            {&H3A, New Tuple(Of String, String)("cleanup", "corrosion")}, _
            {&H3B, New Tuple(Of String, String)("clockwork", "councilman")}, _
            {&H3C, New Tuple(Of String, String)("cobra", "crossover")}, _
            {&H3D, New Tuple(Of String, String)("commence", "crucifix")}, _
            {&H3E, New Tuple(Of String, String)("concert", "cumbersome")}, _
            {&H3F, New Tuple(Of String, String)("cowbell", "customer")}, _
            {&H40, New Tuple(Of String, String)("crackdown", "Dakota")}, _
            {&H41, New Tuple(Of String, String)("cranky", "decadence")}, _
            {&H42, New Tuple(Of String, String)("crowfoot", "December")}, _
            {&H43, New Tuple(Of String, String)("crucial", "decimal")}, _
            {&H44, New Tuple(Of String, String)("crumpled", "designing")}, _
            {&H45, New Tuple(Of String, String)("crusade", "detector")}, _
            {&H46, New Tuple(Of String, String)("cubic", "detergent")}, _
            {&H47, New Tuple(Of String, String)("dashboard", "determine")}, _
            {&H48, New Tuple(Of String, String)("deadbolt", "dictator")}, _
            {&H49, New Tuple(Of String, String)("deckhand", "dinosaur")}, _
            {&H4A, New Tuple(Of String, String)("dogsled", "direction")}, _
            {&H4B, New Tuple(Of String, String)("dragnet", "disable")}, _
            {&H4C, New Tuple(Of String, String)("drainage", "disbelief")}, _
            {&H4D, New Tuple(Of String, String)("dreadful", "disruptive")}, _
            {&H4E, New Tuple(Of String, String)("drifter", "distortion")}, _
            {&H4F, New Tuple(Of String, String)("dropper", "document")}, _
            {&H50, New Tuple(Of String, String)("drumbeat", "embezzle")}, _
            {&H51, New Tuple(Of String, String)("drunken", "enchanting")}, _
            {&H52, New Tuple(Of String, String)("Dupont", "enrollment")}, _
            {&H53, New Tuple(Of String, String)("dwelling", "enterprise")}, _
            {&H54, New Tuple(Of String, String)("eating", "equation")}, _
            {&H55, New Tuple(Of String, String)("edict", "equipment")}, _
            {&H56, New Tuple(Of String, String)("egghead", "escapade")}, _
            {&H57, New Tuple(Of String, String)("eightball", "Eskimo")}, _
            {&H58, New Tuple(Of String, String)("endorse", "everyday")}, _
            {&H59, New Tuple(Of String, String)("endow", "examine")}, _
            {&H5A, New Tuple(Of String, String)("enlist", "existence")}, _
            {&H5B, New Tuple(Of String, String)("erase", "exodus")}, _
            {&H5C, New Tuple(Of String, String)("escape", "fascinate")}, _
            {&H5D, New Tuple(Of String, String)("exceed", "filament")}, _
            {&H5E, New Tuple(Of String, String)("eyeglass", "finicky")}, _
            {&H5F, New Tuple(Of String, String)("eyetooth", "forever")}, _
            {&H60, New Tuple(Of String, String)("facial", "fortitude")}, _
            {&H61, New Tuple(Of String, String)("fallout", "frequency")}, _
            {&H62, New Tuple(Of String, String)("flagpole", "gadgetry")}, _
            {&H63, New Tuple(Of String, String)("flatfoot", "Galveston")}, _
            {&H64, New Tuple(Of String, String)("flytrap", "getaway")}, _
            {&H65, New Tuple(Of String, String)("fracture", "glossary")}, _
            {&H66, New Tuple(Of String, String)("framework", "gossamer")}, _
            {&H67, New Tuple(Of String, String)("freedom", "graduate")}, _
            {&H68, New Tuple(Of String, String)("frighten", "gravity")}, _
            {&H69, New Tuple(Of String, String)("gazelle", "guitarist")}, _
            {&H6A, New Tuple(Of String, String)("Geiger", "hamburger")}, _
            {&H6B, New Tuple(Of String, String)("glitter", "Hamilton")}, _
            {&H6C, New Tuple(Of String, String)("glucose", "handiwork")}, _
            {&H6D, New Tuple(Of String, String)("goggles", "hazardous")}, _
            {&H6E, New Tuple(Of String, String)("goldfish", "headwaters")}, _
            {&H6F, New Tuple(Of String, String)("gremlin", "hemisphere")}, _
            {&H70, New Tuple(Of String, String)("guidance", "hesitate")}, _
            {&H71, New Tuple(Of String, String)("hamlet", "hideaway")}, _
            {&H72, New Tuple(Of String, String)("highchair", "holiness")}, _
            {&H73, New Tuple(Of String, String)("hockey", "hurricane")}, _
            {&H74, New Tuple(Of String, String)("indoors", "hydraulic")}, _
            {&H75, New Tuple(Of String, String)("indulge", "impartial")}, _
            {&H76, New Tuple(Of String, String)("inverse", "impetus")}, _
            {&H77, New Tuple(Of String, String)("involve", "inception")}, _
            {&H78, New Tuple(Of String, String)("island", "indigo")}, _
            {&H79, New Tuple(Of String, String)("jawbone", "inertia")}, _
            {&H7A, New Tuple(Of String, String)("keyboard", "infancy")}, _
            {&H7B, New Tuple(Of String, String)("kickoff", "inferno")}, _
            {&H7C, New Tuple(Of String, String)("kiwi", "informant")}, _
            {&H7D, New Tuple(Of String, String)("klaxon", "insincere")}, _
            {&H7E, New Tuple(Of String, String)("locale", "insurgent")}, _
            {&H7F, New Tuple(Of String, String)("lockup", "integrate")}, _
            {&H80, New Tuple(Of String, String)("merit", "intention")}, _
            {&H81, New Tuple(Of String, String)("minnow", "inventive")}, _
            {&H82, New Tuple(Of String, String)("miser", "Istanbul")}, _
            {&H83, New Tuple(Of String, String)("Mohawk", "Jamaica")}, _
            {&H84, New Tuple(Of String, String)("mural", "Jupiter")}, _
            {&H85, New Tuple(Of String, String)("music", "leprosy")}, _
            {&H86, New Tuple(Of String, String)("necklace", "letterhead")}, _
            {&H87, New Tuple(Of String, String)("Neptune", "liberty")}, _
            {&H88, New Tuple(Of String, String)("newborn", "maritime")}, _
            {&H89, New Tuple(Of String, String)("nightbird", "matchmaker")}, _
            {&H8A, New Tuple(Of String, String)("Oakland", "maverick")}, _
            {&H8B, New Tuple(Of String, String)("obtuse", "Medusa")}, _
            {&H8C, New Tuple(Of String, String)("offload", "megaton")}, _
            {&H8D, New Tuple(Of String, String)("optic", "microscope")}, _
            {&H8E, New Tuple(Of String, String)("orca", "microwave")}, _
            {&H8F, New Tuple(Of String, String)("payday", "midsummer")}, _
            {&H90, New Tuple(Of String, String)("peachy", "millionaire")}, _
            {&H91, New Tuple(Of String, String)("pheasant", "miracle")}, _
            {&H92, New Tuple(Of String, String)("physique", "misnomer")}, _
            {&H93, New Tuple(Of String, String)("playhouse", "molasses")}, _
            {&H94, New Tuple(Of String, String)("Pluto", "molecule")}, _
            {&H95, New Tuple(Of String, String)("preclude", "Montana")}, _
            {&H96, New Tuple(Of String, String)("prefer", "monument")}, _
            {&H97, New Tuple(Of String, String)("preshrunk", "mosquito")}, _
            {&H98, New Tuple(Of String, String)("printer", "narrative")}, _
            {&H99, New Tuple(Of String, String)("prowler", "nebula")}, _
            {&H9A, New Tuple(Of String, String)("pupil", "newsletter")}, _
            {&H9B, New Tuple(Of String, String)("puppy", "Norwegian")}, _
            {&H9C, New Tuple(Of String, String)("python", "October")}, _
            {&H9D, New Tuple(Of String, String)("quadrant", "Ohio")}, _
            {&H9E, New Tuple(Of String, String)("quiver", "onlooker")}, _
            {&H9F, New Tuple(Of String, String)("quota", "opulent")}, _
            {&HA0, New Tuple(Of String, String)("ragtime", "Orlando")}, _
            {&HA1, New Tuple(Of String, String)("ratchet", "outfielder")}, _
            {&HA2, New Tuple(Of String, String)("rebirth", "Pacific")}, _
            {&HA3, New Tuple(Of String, String)("reform", "pandemic")}, _
            {&HA4, New Tuple(Of String, String)("regain", "Pandora")}, _
            {&HA5, New Tuple(Of String, String)("reindeer", "paperweight")}, _
            {&HA6, New Tuple(Of String, String)("rematch", "paragon")}, _
            {&HA7, New Tuple(Of String, String)("repay", "paragraph")}, _
            {&HA8, New Tuple(Of String, String)("retouch", "paramount")}, _
            {&HA9, New Tuple(Of String, String)("revenge", "passenger")}, _
            {&HAA, New Tuple(Of String, String)("reward", "pedigree")}, _
            {&HAB, New Tuple(Of String, String)("rhythm", "Pegasus")}, _
            {&HAC, New Tuple(Of String, String)("ribcage", "penetrate")}, _
            {&HAD, New Tuple(Of String, String)("ringbolt", "perceptive")}, _
            {&HAE, New Tuple(Of String, String)("robust", "performance")}, _
            {&HAF, New Tuple(Of String, String)("rocker", "pharmacy")}, _
            {&HB0, New Tuple(Of String, String)("ruffled", "phonetic")}, _
            {&HB1, New Tuple(Of String, String)("sailboat", "photograph")}, _
            {&HB2, New Tuple(Of String, String)("sawdust", "pioneer")}, _
            {&HB3, New Tuple(Of String, String)("scallion", "pocketful")}, _
            {&HB4, New Tuple(Of String, String)("scenic", "politeness")}, _
            {&HB5, New Tuple(Of String, String)("scorecard", "positive")}, _
            {&HB6, New Tuple(Of String, String)("Scotland", "potato")}, _
            {&HB7, New Tuple(Of String, String)("seabird", "processor")}, _
            {&HB8, New Tuple(Of String, String)("select", "provincial")}, _
            {&HB9, New Tuple(Of String, String)("sentence", "proximate")}, _
            {&HBA, New Tuple(Of String, String)("shadow", "puberty")}, _
            {&HBB, New Tuple(Of String, String)("shamrock", "publisher")}, _
            {&HBC, New Tuple(Of String, String)("showgirl", "pyramid")}, _
            {&HBD, New Tuple(Of String, String)("skullcap", "quantity")}, _
            {&HBE, New Tuple(Of String, String)("skydive", "racketeer")}, _
            {&HBF, New Tuple(Of String, String)("slingshot", "rebellion")}, _
            {&HC0, New Tuple(Of String, String)("slowdown", "recipe")}, _
            {&HC1, New Tuple(Of String, String)("snapline", "recover")}, _
            {&HC2, New Tuple(Of String, String)("snapshot", "repellent")}, _
            {&HC3, New Tuple(Of String, String)("snowcap", "replica")}, _
            {&HC4, New Tuple(Of String, String)("snowslide", "reproduce")}, _
            {&HC5, New Tuple(Of String, String)("solo", "resistor")}, _
            {&HC6, New Tuple(Of String, String)("southward", "responsive")}, _
            {&HC7, New Tuple(Of String, String)("soybean", "retraction")}, _
            {&HC8, New Tuple(Of String, String)("spaniel", "retrieval")}, _
            {&HC9, New Tuple(Of String, String)("spearhead", "retrospect")}, _
            {&HCA, New Tuple(Of String, String)("spellbind", "revenue")}, _
            {&HCB, New Tuple(Of String, String)("spheroid", "revival")}, _
            {&HCC, New Tuple(Of String, String)("spigot", "revolver")}, _
            {&HCD, New Tuple(Of String, String)("spindle", "sandalwood")}, _
            {&HCE, New Tuple(Of String, String)("spyglass", "sardonic")}, _
            {&HCF, New Tuple(Of String, String)("stagehand", "Saturday")}, _
            {&HD0, New Tuple(Of String, String)("stagnate", "savagery")}, _
            {&HD1, New Tuple(Of String, String)("stairway", "scavenger")}, _
            {&HD2, New Tuple(Of String, String)("standard", "sensation")}, _
            {&HD3, New Tuple(Of String, String)("stapler", "sociable")}, _
            {&HD4, New Tuple(Of String, String)("steamship", "souvenir")}, _
            {&HD5, New Tuple(Of String, String)("sterling", "specialist")}, _
            {&HD6, New Tuple(Of String, String)("stockman", "speculate")}, _
            {&HD7, New Tuple(Of String, String)("stopwatch", "stethoscope")}, _
            {&HD8, New Tuple(Of String, String)("stormy", "stupendous")}, _
            {&HD9, New Tuple(Of String, String)("sugar", "supportive")}, _
            {&HDA, New Tuple(Of String, String)("surmount", "surrender")}, _
            {&HDB, New Tuple(Of String, String)("suspense", "suspicious")}, _
            {&HDC, New Tuple(Of String, String)("sweatband", "sympathy")}, _
            {&HDD, New Tuple(Of String, String)("swelter", "tambourine")}, _
            {&HDE, New Tuple(Of String, String)("tactics", "telephone")}, _
            {&HDF, New Tuple(Of String, String)("talon", "therapist")}, _
            {&HE0, New Tuple(Of String, String)("tapeworm", "tobacco")}, _
            {&HE1, New Tuple(Of String, String)("tempest", "tolerance")}, _
            {&HE2, New Tuple(Of String, String)("tiger", "tomorrow")}, _
            {&HE3, New Tuple(Of String, String)("tissue", "torpedo")}, _
            {&HE4, New Tuple(Of String, String)("tonic", "tradition")}, _
            {&HE5, New Tuple(Of String, String)("topmost", "travesty")}, _
            {&HE6, New Tuple(Of String, String)("tracker", "trombonist")}, _
            {&HE7, New Tuple(Of String, String)("transit", "truncated")}, _
            {&HE8, New Tuple(Of String, String)("trauma", "typewriter")}, _
            {&HE9, New Tuple(Of String, String)("treadmill", "ultimate")}, _
            {&HEA, New Tuple(Of String, String)("Trojan", "undaunted")}, _
            {&HEB, New Tuple(Of String, String)("trouble", "underfoot")}, _
            {&HEC, New Tuple(Of String, String)("tumor", "unicorn")}, _
            {&HED, New Tuple(Of String, String)("tunnel", "unify")}, _
            {&HEE, New Tuple(Of String, String)("tycoon", "universe")}, _
            {&HEF, New Tuple(Of String, String)("uncut", "unravel")}, _
            {&HF0, New Tuple(Of String, String)("unearth", "upcoming")}, _
            {&HF1, New Tuple(Of String, String)("unwind", "vacancy")}, _
            {&HF2, New Tuple(Of String, String)("uproot", "vagabond")}, _
            {&HF3, New Tuple(Of String, String)("upset", "vertigo")}, _
            {&HF4, New Tuple(Of String, String)("upshot", "Virginia")}, _
            {&HF5, New Tuple(Of String, String)("vapor", "visitor")}, _
            {&HF6, New Tuple(Of String, String)("village", "vocalist")}, _
            {&HF7, New Tuple(Of String, String)("virus", "voyager")}, _
            {&HF8, New Tuple(Of String, String)("Vulcan", "warranty")}, _
            {&HF9, New Tuple(Of String, String)("waffle", "Waterloo")}, _
            {&HFA, New Tuple(Of String, String)("wallet", "whimsical")}, _
            {&HFB, New Tuple(Of String, String)("watchword", "Wichita")}, _
            {&HFC, New Tuple(Of String, String)("wayside", "Wilmington")}, _
            {&HFD, New Tuple(Of String, String)("willow", "Wyoming")}, _
            {&HFE, New Tuple(Of String, String)("woodlark", "yesteryear")}, _
            {&HFF, New Tuple(Of String, String)("Zulu", "Yucatan")} _
        }
        Private Shared Sub Main(args As String())
            Dim stdIn As Stream = Console.OpenStandardInput()
            Dim stdOut As Stream = Console.OpenStandardOutput()
            Dim fileIn As Stream = New MemoryStream()
            Dim inputStream As Stream = New MemoryStream()

            If args.Length = 1 Then
                Try
                    fileIn = File.Open(args(0), FileMode.Open)
                Catch e As FileNotFoundException
                    If e IsNot Nothing Then
                        Console.[Error].WriteLine("The specified file was not found.")
                        Console.[Error].WriteLine("Please either use stdIn or specify the path to a binary file to encode.")
                        Return
                    End If
                End Try
                inputStream = fileIn
            ElseIf args.Length = 0 Then
                Try
                    Dim tmp As Boolean = Console.KeyAvailable
                    Console.[Error].WriteLine("Invalid command line arguments or no input detected.")
                    Console.[Error].WriteLine("Please either use stdIn or specify the path to a binary file to encode.")
                    Return
                Catch e As InvalidOperationException
                    'Do nothing.
                    If e IsNot Nothing Then
                    End If
                End Try
                inputStream = stdIn
            End If

            Dim buffer As Byte() = New Byte(0) {}
            'Dim debugInput As Byte() = New Byte() {&H7F, &H7F, &H34, &H90, &H1E, &H34, &H5A, &H9B}
            'inputStream = New MemoryStream(debugInput)
            Dim bytes As Integer
            Dim oddByte As Boolean = False
            Dim firstByte As Boolean = True
            While (InlineAssignHelper(bytes, inputStream.Read(buffer, 0, buffer.Length))) > 0
                Dim biometricByte As String = String.Empty
                If firstByte <> True Then
                    biometricByte = String.Concat(biometricByte, " ")
                Else
                    firstByte = False
                End If
                Dim biometricTuple As Tuple(Of String, String) = WordDictionary.Where(Function(x) x.Key = buffer(0)).First().Value
                Dim biometricWord As String = String.Empty
                If oddByte = False Then
                    biometricWord = biometricTuple.Item1
                Else
                    biometricWord = biometricTuple.Item2
                End If
                oddByte = Not oddByte
                biometricByte = String.Concat(biometricByte, biometricWord)
                Dim biometricByteArray As Byte() = Encoding.UTF8.GetBytes(biometricByte)
                stdOut.Write(biometricByteArray, 0, biometricByteArray.Length)
            End While
        End Sub
        Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
            target = value
            Return value
        End Function
    End Class
End Namespace

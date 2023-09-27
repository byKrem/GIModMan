using Newtonsoft.Json.Linq;

namespace Tests
{
    public class GameBabanaAPIWorkTests
    {
        private static GameBananaAPIWork APIWork;


        static GameBabanaAPIWorkTests()
        {
            APIWork = new GameBananaAPIWork();
        }

        [Test]
        public async Task GetListNewTest()
        {
            List<Mod> mods = await APIWork.GetListAsync<Mod>(1,10);
            Assert.That(mods, Is.Not.Null);
        }

        [Test]
        public async Task GetItemDataTest()
        {

            Mod expected = new Mod()
            {
                Id = 464395,
                Name = "Outline Removal",
                Category = new ModCategory()
                {
                    ID = 12526,
                    Name = "Other\\Misc",
                    IconUrl = new Uri("https://images.gamebanana.com/img/ico/ModCategory/6330aa91775d8.png")
                },
                IsNSFW = false,
                CreationDate = UnixTimeToDateTimeConverter.FromUnixTime(1692865436),
                ModificationDate = UnixTimeToDateTimeConverter.FromUnixTime(1695785228),
                Submitter = new JArray
                {
                    new JArray
                    {
                        "NiniTrance",
                        "Literally just tinkered in notepad lmfao",
                        2352177,
                        ""
                    }
                },
                Files = new List<ModFile>()
                {
                    new ModFile()
                    {
                        Id = 1042697,
                        FileName = "outline_removal.zip",
                        Filesize = 2735,
                        Description = "",
                        DateAdded = UnixTimeToDateTimeConverter.FromUnixTime(1692864575),
                        DownloadCount = 147,
                        AnalysisState = "done",
                        DownloadUrl = new Uri(@"https://gamebanana.com/dl/1042697"),
                        Md5Checksum = "7cf6157ca772dd3f74d2895729512ddb",
                        ClamAvResult = "clean",
                        AnalysisResult = "File passed analysis",
                        ContainsExe = false
                    }
                }
            };

            Mod actual = await APIWork.GetItemAsync<Mod>(464395);
            Assert.That(actual, Is.SameAs(expected));
        }
    }
}
using NSubstitute;
using DemoApp2025Spring.Shared;
using Xunit;
using Assert = Xunit.Assert;
using Microsoft.Extensions.Logging;

namespace KonyvtarAPI.Tests
{
    [TestClass()]
    public class OlvasokServiceUnitTests
    {
        private OlvasokService CreateService(out ILogger<OlvasokService> logger)
        {
            logger = Substitute.For<ILogger<OlvasokService>>();
            return new OlvasokService(logger);
        }

        [Fact]
        public void AddTest()
        {
            // Arrange
            var service = CreateService(out var logger);
            var olvaso = new Olvasok
            {
                OlvasoSzam = 1,
                OlvasoNev = "Teszt Elek",
                Lakcim = "Teszt utca 1.",
                SzuletesiDatum = new DateOnly(2000, 1, 1)
            };

            // Act
            service.Add(olvaso);

            // Assert
            var all = service.GetAllOlvasok();
            Assert.Single(all);
            Assert.Equal(olvaso, all[0]);
            logger.Received().LogInformation("Olvasó hozzáadva");
        }

        [Fact]
        public void GetAllOlvasokTest()
        {
            // Arrange
            var service = CreateService(out _);
            var olvaso1 = new Olvasok
            {
                OlvasoSzam = 1,
                OlvasoNev = "Teszt Elek",
                Lakcim = "Teszt utca 1.",
                SzuletesiDatum = new DateOnly(2000, 1, 1)
            };
            var olvaso2 = new Olvasok
            {
                OlvasoSzam = 2,
                OlvasoNev = "Minta Anna",
                Lakcim = "Minta utca 2.",
                SzuletesiDatum = new DateOnly(1995, 5, 5)
            };
            service.Add(olvaso1);
            service.Add(olvaso2);

            // Act
            var all = service.GetAllOlvasok();

            // Assert
            Assert.Equal(2, all.Count);
            Assert.Contains(olvaso1, all);
            Assert.Contains(olvaso2, all);
        }

        [Fact]
        public void DeleteTest()
        {
            // Arrange
            var service = CreateService(out var logger);
            var olvaso = new Olvasok
            {
                OlvasoSzam = 1,
                OlvasoNev = "Teszt Elek",
                Lakcim = "Teszt utca 1.",
                SzuletesiDatum = new DateOnly(2000, 1, 1)
            };
            service.Add(olvaso);

            // Act
            service.Delete(1);

            // Assert
            Assert.Empty(service.GetAllOlvasok());
            logger.Received().LogInformation("Olvasó törölve");
        }

        [Fact]
        public void UpdateTest()
        {
            // Arrange
            var service = CreateService(out var logger);
            var olvaso = new Olvasok
            {
                OlvasoSzam = 1,
                OlvasoNev = "Teszt Elek",
                Lakcim = "Teszt utca 1.",
                SzuletesiDatum = new DateOnly(2000, 1, 1)
            };
            service.Add(olvaso);

            var updated = new Olvasok
            {
                OlvasoSzam = 1,
                OlvasoNev = "Frissített Név",
                Lakcim = "Új cím 2.",
                SzuletesiDatum = new DateOnly(1999, 12, 31)
            };

            // Act
            service.Update(updated);

            // Assert
            var result = service.GetOlvaso(1);
            Assert.Equal("Frissített Név", result.OlvasoNev);
            Assert.Equal("Új cím 2.", result.Lakcim);
            Assert.Equal(new DateOnly(1999, 12, 31), result.SzuletesiDatum);
            logger.Received().LogInformation("Olvasó frissítve");
        }

        [Fact]
        public void GetOlvasoTest()
        {
            // Arrange
            var service = CreateService(out _);
            var olvaso = new Olvasok
            {
                OlvasoSzam = 1,
                OlvasoNev = "Teszt Elek",
                Lakcim = "Teszt utca 1.",
                SzuletesiDatum = new DateOnly(2000, 1, 1)
            };
            service.Add(olvaso);

            // Act
            var result = service.GetOlvaso(1);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(olvaso.OlvasoNev, result.OlvasoNev);
            Assert.Equal(olvaso.Lakcim, result.Lakcim);
            Assert.Equal(olvaso.SzuletesiDatum, result.SzuletesiDatum);
        }
    }
}
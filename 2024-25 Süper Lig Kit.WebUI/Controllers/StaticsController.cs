using Microsoft.AspNetCore.Mvc;

namespace _2024_25_Süper_Lig_Kit.WebUI.Controllers
{
    public class StaticsController : Controller
    {
        // Ana dashboard sayfası
        public IActionResult Index()
        {
            return View();
        }

        // Forma-Başarı Korelasyonu analiz sayfası
        public IActionResult KitSuccessCorrelation()
        {
            return View();
        }

        // İç Saha Avantajı & Forma analiz sayfası
        public IActionResult HomeAdvantageByKit()
        {
            return View();
        }

        // Forma Kullanım Heatmap analiz sayfası
        public IActionResult KitUsageHeatmap()
        {
            return View();
        }

        // Kaleci Forma Kullanım Heatmap analiz sayfası
        public IActionResult GoalkeeperKitUsageHeatmap()
        {
            return View();
        }

        // Haftalık Forma Trendleri analiz sayfası
        public IActionResult WeeklyKitTrends()
        {
            return View();
        }

        // Network Analizi sayfası
        public IActionResult NetworkAnalysis()
        {
            return View();
        }

        // Hakem Forma Analizi sayfası
        public IActionResult RefereeAnalysis()
        {
            return View();
        }

        // Kaleci Forma Performansı (ek analiz)
        public IActionResult GoalkeeperKitPerformance()
        {
            return View();
        }

        // Sezon Sonu Analizi (ek analiz)
        public IActionResult SeasonEndAnalysis()
        {
            return View();
        }

        // Kritik Maç Forma Tercihleri (ek analiz)
        public IActionResult CriticalMatchAnalysis()
        {
            return View();
        }

        // En Çok Forma Değiştiren Takımlar (ek analiz)
        public IActionResult TeamKitDiversity()
        {
            return View();
        }

        // Skor Dağılımı Analizi (ek analiz)
        public IActionResult ScoreDistributionByKit()
        {
            return View();
        }

        // Zaman Serisi Analizi (ek analiz)
        public IActionResult TimeSeriesAnalysis()
        {
            return View();
        }
    }
} 
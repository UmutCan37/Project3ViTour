using iTextSharp.text.pdf;
using iTextSharp.text;
using Microsoft.AspNetCore.Mvc;
using Project3ViTour.Dtos.BookingDtos;
using Project3ViTour.Services.BookingService;
using System.Threading.Tasks;
using Project3ViTour.Services.TourService;
using iTextSharp.text.pdf.draw;

namespace Project3ViTour.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly ITourService _tourService;

        public BookingController(IBookingService bookingService, ITourService tourService)
        {
            _bookingService = bookingService;
            _tourService = tourService;
        }

        public async Task<IActionResult> Index()
        {
            var bookings = await _bookingService.GetAllBookingAsync();
            var tours = await _tourService.GetAllToursAsync();
            ViewBag.Tours = tours;
            return View(bookings);
        }
        [HttpGet]
        public async Task<IActionResult> CreateBooking()
        {
            var tours = await _tourService.GetAllToursAsync();
            ViewBag.Tours = tours;
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDto createBookingDto)
        {
            await _bookingService.CreateBookingAsync(createBookingDto);
            return RedirectToAction("Index");
        }

        
        [HttpGet]
        public async Task<IActionResult> UpdateBooking(string id)
        {
            var value = await _bookingService.GetBookingByIdAsync(id);
            var tours = await _tourService.GetAllToursAsync();
            ViewBag.Tours = tours;
            return View(value);
        }

        
        [HttpPost]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            await _bookingService.UpdateBookingAsync(updateBookingDto);
            return RedirectToAction("Index");
        }

        
        public async Task<IActionResult> DeleteBooking(string id)
        {
            await _bookingService.DeleteBookingAsync(id);
            return RedirectToAction("Index");
        }

        
        [HttpGet]
        public async Task<IActionResult> ExportTourBookingsPdf(string id)
        {
            if (string.IsNullOrEmpty(id))
                return Content("TourId boş geliyor!");

            var bookings = await _bookingService.GetBookingsByTourIdAsync(id);
            if (!bookings.Any())
                return Content($"TourId: {id} - Booking bulunamadı!");

            
            var tour = await _tourService.GetTourByIdAsync(id);

            using var ms = new MemoryStream();
            var document = new Document(PageSize.A4, 36, 36, 36, 36);
            var writer = PdfWriter.GetInstance(document, ms);
            document.Open();

            
            var darkGreen = new BaseColor(27, 94, 32);
            var medGreen = new BaseColor(46, 125, 50);
            var lightGreen = new BaseColor(232, 245, 233);
            var accentGreen = new BaseColor(76, 175, 80);
            var white = BaseColor.White;
            var lightGray = new BaseColor(248, 250, 248);
            var borderGray = new BaseColor(200, 230, 201);
            var textDark = new BaseColor(27, 38, 27);
            var textMuted = new BaseColor(102, 126, 102);

            
            var fontTitle = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 22, white);
            var fontSubtitle = FontFactory.GetFont(FontFactory.HELVETICA, 10, new BaseColor(178, 223, 178));
            var fontSection = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11, darkGreen);
            var fontLabel = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9, textMuted);
            var fontValue = FontFactory.GetFont(FontFactory.HELVETICA, 9, textDark);
            var fontHeader = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9, white);
            var fontCell = FontFactory.GetFont(FontFactory.HELVETICA, 9, textDark);
            var fontCellBold = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9, textDark);
            var fontFooter = FontFactory.GetFont(FontFactory.HELVETICA, 8, textMuted);
            var fontTotal = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10, darkGreen);
            var fontBadge = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8, white);

            
            var headerTable = new PdfPTable(2) { WidthPercentage = 100 };
            headerTable.SetWidths(new float[] { 3f, 1f });
            headerTable.SpacingAfter = 20f;

            
            var leftCell = new PdfPCell
            {
                BackgroundColor = darkGreen,
                Border = 0,
                Padding = 22,
                PaddingLeft = 28
            };
            leftCell.AddElement(new Paragraph("Rezervasyon Raporu", fontTitle) { SpacingAfter = 4 });
            leftCell.AddElement(new Paragraph($"Oluşturulma: {DateTime.Now:dd MMMM yyyy, HH:mm}", fontSubtitle));
            headerTable.AddCell(leftCell);

            
            var rightCell = new PdfPCell
            {
                BackgroundColor = medGreen,
                Border = 0,
                Padding = 22,
                HorizontalAlignment = Element.ALIGN_CENTER,
                VerticalAlignment = Element.ALIGN_MIDDLE
            };
            rightCell.AddElement(new Paragraph("ViTour", FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18, white))
            { Alignment = Element.ALIGN_CENTER });
            rightCell.AddElement(new Paragraph("Admin Panel", FontFactory.GetFont(FontFactory.HELVETICA, 9, new BaseColor(178, 223, 178)))
            { Alignment = Element.ALIGN_CENTER });
            headerTable.AddCell(rightCell);
            document.Add(headerTable);

            
            if (tour != null)
            {
                
                var tourSectionTitle = new Paragraph("Tur Bilgileri", fontSection);
                tourSectionTitle.SpacingAfter = 8f;
                document.Add(tourSectionTitle);

                var tourInfoTable = new PdfPTable(4) { WidthPercentage = 100 };
                tourInfoTable.SetWidths(new float[] { 1f, 1.5f, 1f, 1.5f });
                tourInfoTable.SpacingAfter = 20f;

                void AddInfoCell(string label, string value, BaseColor bg = null)
                {
                    bg = bg ?? lightGreen;
                    var cell = new PdfPCell
                    {
                        BackgroundColor = bg,
                        Border = 0,
                        Padding = 10,
                        PaddingLeft = 12
                    };
                    cell.AddElement(new Paragraph(label, fontLabel) { SpacingAfter = 2 });
                    cell.AddElement(new Paragraph(value ?? "—", fontValue));
                    tourInfoTable.AddCell(cell);
                }

                AddInfoCell("TUR ADI", tour.Title);
                AddInfoCell("KAPASıTE", $"{tour.Capacity} kisi");
                AddInfoCell("SÜRE", $"{tour.DayCount} gün");
                AddInfoCell("FIYAT", $"₺{tour.Price:N2} / kisi");

                document.Add(tourInfoTable);
            }

            
            var summaryTitle = new Paragraph("Rezervasyon Özeti", fontSection);
            summaryTitle.SpacingAfter = 8f;
            document.Add(summaryTitle);

            int totalGuests = bookings.Sum(b => b.GuestCount);
            decimal totalRevenue = bookings.Sum(b => b.TotalPrice);
            int activeBookings = bookings.Count(b => b.IsStatus);

            var summaryTable = new PdfPTable(4) { WidthPercentage = 100 };
            summaryTable.SetWidths(new float[] { 1f, 1f, 1f, 1f });
            summaryTable.SpacingAfter = 20f;

            void AddSummaryCard(string label, string value, BaseColor bgColor, BaseColor textColor)
            {
                var cell = new PdfPCell
                {
                    BackgroundColor = bgColor,
                    Border = 0,
                    Padding = 14,
                    HorizontalAlignment = Element.ALIGN_CENTER
                };
                cell.AddElement(new Paragraph(value, FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16, textColor))
                { Alignment = Element.ALIGN_CENTER, SpacingAfter = 4 });
                cell.AddElement(new Paragraph(label, FontFactory.GetFont(FontFactory.HELVETICA, 8, textColor))
                { Alignment = Element.ALIGN_CENTER });
                summaryTable.AddCell(cell);
            }

            AddSummaryCard("TOPLAM REZ.", bookings.Count.ToString(), lightGreen, darkGreen);
            AddSummaryCard("AKTIF", activeBookings.ToString(), new BaseColor(209, 250, 229), new BaseColor(6, 95, 70));
            AddSummaryCard("TOPLAM MISAFIR", totalGuests.ToString(), new BaseColor(224, 242, 254), new BaseColor(7, 89, 133));
            AddSummaryCard("TOPLAM GELIR", $"₺{totalRevenue:N0}", new BaseColor(254, 243, 199), new BaseColor(120, 53, 15));

            document.Add(summaryTable);

            
            var tableSectionTitle = new Paragraph("Rezervasyon Listesi", fontSection);
            tableSectionTitle.SpacingAfter = 8f;
            document.Add(tableSectionTitle);

            var mainTable = new PdfPTable(7) { WidthPercentage = 100 };
            mainTable.SetWidths(new float[] { 2.2f, 2f, 1.6f, 1f, 1.4f, 1.4f, 1f });
            mainTable.SpacingAfter = 16f;

            
            string[] headers = { "Ad Soyad", "E-posta", "Telefon", "Misafir", "Toplam", "Tarih", "Durum" };
            foreach (var h in headers)
            {
                var hCell = new PdfPCell(new Phrase(h, fontHeader))
                {
                    BackgroundColor = darkGreen,
                    Padding = 10,
                    PaddingLeft = 10,
                    Border = 0,
                    HorizontalAlignment = Element.ALIGN_LEFT
                };
                mainTable.AddCell(hCell);
            }

            
            bool alt = false;
            foreach (var b in bookings.OrderByDescending(x => x.BookingDate))
            {
                var rowBg = alt ? lightGray : white;

                PdfPCell MakeCell(string text, bool bold = false, int align = Element.ALIGN_LEFT)
                {
                    var f = bold ? fontCellBold : fontCell;
                    return new PdfPCell(new Phrase(text ?? "—", f))
                    {
                        BackgroundColor = rowBg,
                        Padding = 9,
                        PaddingLeft = 10,
                        Border = 0,
                        BorderWidthBottom = 0.3f,
                        BorderColorBottom = borderGray,
                        HorizontalAlignment = align
                    };
                }

                mainTable.AddCell(MakeCell(b.NameSurname, bold: true));
                mainTable.AddCell(MakeCell(b.Email));
                mainTable.AddCell(MakeCell(b.Phone));
                mainTable.AddCell(MakeCell(b.GuestCount.ToString(), align: Element.ALIGN_CENTER));
                mainTable.AddCell(MakeCell($"₺{b.TotalPrice:N0}", bold: true));
                mainTable.AddCell(MakeCell(b.BookingDate.ToString("dd.MM.yyyy")));

                
                var statusCell = new PdfPCell
                {
                    BackgroundColor = rowBg,
                    Padding = 9,
                    PaddingLeft = 10,
                    Border = 0,
                    BorderWidthBottom = 0.3f,
                    BorderColorBottom = borderGray,
                    HorizontalAlignment = Element.ALIGN_CENTER,
                    VerticalAlignment = Element.ALIGN_MIDDLE
                };

                var badgeBg = b.IsStatus ? new BaseColor(209, 250, 229) : new BaseColor(241, 245, 249);
                var badgeText = b.IsStatus ? new BaseColor(6, 95, 70) : new BaseColor(100, 116, 139);
                var badgeFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 8, badgeText);

                var innerTable = new PdfPTable(1) { WidthPercentage = 90 };
                var badgeCell = new PdfPCell(new Phrase(b.IsStatus ? "Aktif" : "Pasif", badgeFont))
                {
                    BackgroundColor = badgeBg,
                    Border = 0,
                    Padding = 4,
                    HorizontalAlignment = Element.ALIGN_CENTER
                };
                innerTable.AddCell(badgeCell);
                statusCell.AddElement(innerTable);
                mainTable.AddCell(statusCell);

                alt = !alt;
            }

            document.Add(mainTable);

            
            var footerLine = new LineSeparator(0.5f, 100f, borderGray, Element.ALIGN_CENTER, -2);
            document.Add(new Chunk(footerLine));

            var footerTable = new PdfPTable(2) { WidthPercentage = 100 };
            footerTable.SpacingBefore = 10f;

            var footerLeft = new PdfPCell(new Phrase($"ViTour Admin Panel — {DateTime.Now:yyyy}", fontFooter))
            { Border = 0, Padding = 6 };
            var footerRight = new PdfPCell(new Phrase($"Toplam {bookings.Count} rezervasyon | ₺{totalRevenue:N0} gelir", fontFooter))
            { Border = 0, Padding = 6, HorizontalAlignment = Element.ALIGN_RIGHT };

            footerTable.AddCell(footerLeft);
            footerTable.AddCell(footerRight);
            document.Add(footerTable);

            document.Close();
            return File(ms.ToArray(), "application/pdf", $"rezervasyon-raporu-{tour?.Title ?? id}-{DateTime.Now:yyyyMMdd}.pdf");
        }
    }
}

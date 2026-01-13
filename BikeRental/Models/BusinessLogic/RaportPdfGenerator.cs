using BikeRental.Models.EntitiesForView;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
namespace BikeRental.Models.BusinessLogic
{
    public static class RaportPdfGenerator
    {
        public static void Generate(RaportPodsumowanieDto r, string filePath)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(30);
                    page.DefaultTextStyle(x => x.FontSize(11));

                    page.Header()
                        .Text("Raport wypożyczeń – podsumowanie")
                        .FontSize(18)
                        .SemiBold();

                    page.Content().Column(col =>
                    {
                        col.Spacing(10);

                        col.Item().Text($"Okres: {r.Od:yyyy-MM-dd} – {r.Do:yyyy-MM-dd}");

                        col.Item().LineHorizontal(1);

                        col.Item().Text("Filtry:").SemiBold();
                        col.Item().Text($"KlientId: {r.KlientId?.ToString() ?? "-"}");
                        col.Item().Text($"RowerId: {r.RowerId?.ToString() ?? "-"}");
                        col.Item().Text($"Stacja start: {r.StacjaStartId?.ToString() ?? "-"}");
                        col.Item().Text($"Stacja koniec: {r.StacjaKoniecId?.ToString() ?? "-"}");

                        col.Item().LineHorizontal(1);

                        col.Item().Text("Wyniki:").SemiBold();

                        col.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn();
                                columns.RelativeColumn();
                            });

                            void Row(string label, string value)
                            {
                                table.Cell().PaddingVertical(4).Text(label);
                                table.Cell().PaddingVertical(4).AlignRight().Text(value).SemiBold();
                            }

                            Row("Liczba wypożyczeń", r.LiczbaWypozyczen.ToString());
                            Row("Łączny czas [min]", r.LacznyCzasMin.ToString());
                            Row("Łączny dystans [km]", r.LacznyDystansKm.ToString("0.00"));
                            Row("Przychód", r.Przychod.ToString("0.00"));
                        });
                    });

                    page.Footer()
                    .AlignRight()
                    .DefaultTextStyle(t => t
                        .FontSize(9)
                        .FontColor(Colors.Grey.Darken1))
                    .Text(x =>
                    {
                        x.Span("Wygenerowano: ");
                        x.Span(DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
                    });
                });
            })
            .GeneratePdf(filePath);
        }
    }
}

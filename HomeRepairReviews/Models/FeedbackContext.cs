using Microsoft.EntityFrameworkCore;

namespace HomeRepairReviews.Models;

public class FeedbackContext : DbContext
{
    public DbSet<Feedback> Feedbacks { get; set; }

    public DbSet<FeedbackPhoto> FeedbackPhotos { get; set; }

    public FeedbackContext(DbContextOptions<FeedbackContext> options)
        : base(options)
    {
        if (Database.EnsureCreated())
        {
            var feedback1 = new Feedback
            {
                UserName = "Михайло Петров",
                Date = new DateTime(2026, 9, 10),
                Master = "Олександр Іванов",
                WorkType = "Ремонт квартири",
                Text = "Замовляли ремонт квартири, результатом залишилися задоволені. Все зробили акуратно."
            };

            feedback1.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont1.jpg" });
            feedback1.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont2.jpg" });
            feedback1.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont3.jpg" });


            var feedback2 = new Feedback
            {
                UserName = "Андрій Коваль",
                Date = new DateTime(2026, 9, 11),
                Master = "Віктор Мельник",
                WorkType = "Ремонт стін",
                Text = "Майстри добре виконали свою роботу. Особливо сподобалося, як зробили стіни."
            };

            feedback2.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont4.jpg" });
            feedback2.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont5.jpg" });
            feedback2.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont6.jpg" });
            feedback2.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont7.jpg" });


            var feedback3 = new Feedback
            {
                UserName = "Олена Шевченко",
                Date = new DateTime(2026, 9, 12),
                Master = "Андрій Кравець",
                WorkType = "Ремонт ванної кімнати",
                Text = "Ремонт у ванній кімнаті зробили швидко та якісно. Плитка покладена рівно."
            };

            feedback3.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont8.jpg" });
            feedback3.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont9.jpg" });
            feedback3.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont10.jpg" });


            var feedback4 = new Feedback
            {
                UserName = "Іван Мельник",
                Date = new DateTime(2026, 9, 13),
                Master = "Сергій Бондар",
                WorkType = "Ремонт спальні",
                Text = "Дуже задоволений результатом ремонту. Все виглядає саме так, як ми хотіли."
            };

            feedback4.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont1.jpg" });
            feedback4.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont5.jpg" });
            feedback4.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont8.jpg" });


            var feedback5 = new Feedback
            {
                UserName = "Анна Бондар",
                Date = new DateTime(2026, 9, 14),
                Master = "Олександр Іванов",
                WorkType = "Ремонт кухні",
                Text = "Робили ремонт кухні. Робота виконана акуратно, після себе майстри все прибрали."
            };

            feedback5.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont2.jpg" });
            feedback5.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont6.jpg" });
            feedback5.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont9.jpg" });
            feedback5.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont10.jpg" });


            var feedback6 = new Feedback
            {
                UserName = "Максим Ткаченко",
                Date = new DateTime(2026, 9, 15),
                Master = "Віктор Мельник",
                WorkType = "Косметичний ремонт",
                Text = "Сподобалося ставлення до клієнта. Усі деталі ремонту попередньо обговорили."
            };

            feedback6.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont3.jpg" });
            feedback6.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont7.jpg" });
            feedback6.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont10.jpg" });


            var feedback7 = new Feedback
            {
                UserName = "Софія Лисенко",
                Date = new DateTime(2026, 9, 16),
                Master = "Андрій Кравець",
                WorkType = "Ремонт квартири",
                Text = "Хороший результат за адекватну ціну. Рекомендую звернутися тим, хто планує ремонт."
            };

            feedback7.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont1.jpg" });
            feedback7.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont4.jpg" });
            feedback7.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont8.jpg" });


            var feedback8 = new Feedback
            {
                UserName = "Дмитро Кравець",
                Date = new DateTime(2026, 9, 17),
                Master = "Сергій Бондар",
                WorkType = "Фарбування стін",
                Text = "Повністю переробляли спальню. Дуже сподобався колір стін та якість фарбування."
            };

            feedback8.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont2.jpg" });
            feedback8.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont5.jpg" });
            feedback8.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont7.jpg" });
            feedback8.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont9.jpg" });


            var feedback9 = new Feedback
            {
                UserName = "Катерина Романенко",
                Date = new DateTime(2026, 9, 18),
                Master = "Олександр Іванов",
                WorkType = "Ремонт квартири",
                Text = "Робили ремонт у двокімнатній квартирі. Робота зайняла менше часу, ніж очікували."
            };

            feedback9.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont3.jpg" });
            feedback9.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont6.jpg" });
            feedback9.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont10.jpg" });


            var feedback10 = new Feedback
            {
                UserName = "Адмін Адміністратор",
                Date = new DateTime(2026, 9, 19),
                Master = "Віктор Мельник",
                WorkType = "Встановлення дверей",
                Text = "Дуже акуратно встановили двері та плінтуси. Результат сподобався."
            };

            feedback10.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont1.jpg" });
            feedback10.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont4.jpg" });
            feedback10.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont6.jpg" });


            var feedback11 = new Feedback
            {
                UserName = "Михайло Петров",
                Date = new DateTime(2026, 9, 20),
                Master = "Андрій Кравець",
                WorkType = "Косметичний ремонт",
                Text = "Замовляли косметичний ремонт. Все зробили без зайвих проблем."
            };

            feedback11.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont2.jpg" });
            feedback11.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont5.jpg" });
            feedback11.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont8.jpg" });


            var feedback12 = new Feedback
            {
                UserName = "Андрій Коваль",
                Date = new DateTime(2026, 9, 21),
                Master = "Сергій Бондар",
                WorkType = "Ремонт стін",
                Text = "Сподобалася якість роботи. Майстри відповідали на всі запитання та враховували наші побажання."
            };

            feedback12.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont3.jpg" });
            feedback12.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont7.jpg" });
            feedback12.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont9.jpg" });


            var feedback13 = new Feedback
            {
                UserName = "Олена Шевченко",
                Date = new DateTime(2026, 9, 22),
                Master = "Олександр Іванов",
                WorkType = "Ремонт підлоги",
                Text = "Після ремонту квартира виглядає зовсім по-новому. Особливо сподобалася підлога."
            };

            feedback13.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont1.jpg" });
            feedback13.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont5.jpg" });
            feedback13.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont10.jpg" });


            var feedback14 = new Feedback
            {
                UserName = "Іван Мельник",
                Date = new DateTime(2026, 9, 23),
                Master = "Віктор Мельник",
                WorkType = "Ремонт дитячої кімнати",
                Text = "Робили ремонт у дитячій кімнаті. Все вийшло гарно та акуратно."
            };

            feedback14.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont2.jpg" });
            feedback14.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont4.jpg" });
            feedback14.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont8.jpg" });


            var feedback15 = new Feedback
            {
                UserName = "Анна Бондар",
                Date = new DateTime(2026, 9, 24),
                Master = "Андрій Кравець",
                WorkType = "Ремонт квартири",
                Text = "Дякую за якісну роботу. Результатом ремонту залишилися задоволені всією сім'єю."
            };

            feedback15.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont3.jpg" });
            feedback15.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont6.jpg" });
            feedback15.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont9.jpg" });


            var feedback16 = new Feedback
            {
                UserName = "Максим Ткаченко",
                Date = new DateTime(2026, 9, 25),
                Master = "Сергій Бондар",
                WorkType = "Ремонт кухні",
                Text = "Ремонтували коридор та кухню. Все зроблено чисто і без пошкодження меблів."
            };

            feedback16.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont1.jpg" });
            feedback16.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont4.jpg" });
            feedback16.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont7.jpg" });
            feedback16.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont10.jpg" });


            var feedback17 = new Feedback
            {
                UserName = "Софія Лисенко",
                Date = new DateTime(2026, 9, 26),
                Master = "Олександр Іванов",
                WorkType = "Косметичний ремонт",
                Text = "Майстри швидко виконали поставлені завдання. Якість роботи хороша."
            };

            feedback17.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont2.jpg" });
            feedback17.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont5.jpg" });
            feedback17.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont8.jpg" });


            var feedback18 = new Feedback
            {
                UserName = "Дмитро Кравець",
                Date = new DateTime(2026, 9, 27),
                Master = "Віктор Мельник",
                WorkType = "Ремонт ванної кімнати",
                Text = "Дуже сподобався результат ремонту ванної. Все виглядає сучасно."
            };

            feedback18.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont3.jpg" });
            feedback18.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont6.jpg" });
            feedback18.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont9.jpg" });
            feedback18.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont10.jpg" });


            var feedback19 = new Feedback
            {
                UserName = "Катерина Романенко",
                Date = new DateTime(2026, 9, 28),
                Master = "Андрій Кравець",
                WorkType = "Ремонт новобудови",
                Text = "Зробили ремонт у новобудові. Робота виконана якісно та відповідно до домовленостей."
            };

            feedback19.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont1.jpg" });
            feedback19.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont5.jpg" });
            feedback19.Photos.Add(new FeedbackPhoto { PhotoPath = "/feedback/remont8.jpg" });


            Feedbacks.AddRange(
                feedback1,
                feedback2,
                feedback3,
                feedback4,
                feedback5,
                feedback6,
                feedback7,
                feedback8,
                feedback9,
                feedback10,
                feedback11,
                feedback12,
                feedback13,
                feedback14,
                feedback15,
                feedback16,
                feedback17,
                feedback18,
                feedback19
            );

            SaveChanges();
        }
    }
}

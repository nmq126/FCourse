﻿namespace FCourse.Migrations
{
    using FCourse.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<FCourse.Data.DBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FCourse.Data.DBContext context)
        {
            context.Users.AddOrUpdate(x => x.Id,
                 new User() { Id = "1", FirstName = "Vũ", LastName = "Anh", PhoneNumber = "0321154356", Description = "Web developer", Email = "Jimmianh1807@gmail.com", Password = "0987888008", Salt = "423425", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, DisabledAt = DateTime.Now, Status = 1, LockoutEnabled = false, TwoFactorEnabled = false, AccessFailedCount = 0, UserName = "q", PhoneNumberConfirmed = false },
                 new User() { Id = "2", FirstName = "Nguyễn", LastName = "Tân", PhoneNumber = "0986007605", Description = "iMBA graduate, University of Illinois Gies College of Business", Email = "Jimmianh@gmail.com", Password = "0987888007", Salt = "423325", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, DisabledAt = DateTime.Now, Status = 1, LockoutEnabled = false, TwoFactorEnabled = false, AccessFailedCount = 0, UserName = "sd", PhoneNumberConfirmed = false },
                 new User() { Id = "3", FirstName = "Hoàng", LastName = "Anh", PhoneNumber = "0986007606", Description = "Student who obtained a Professional Certificate in IBM Data Science", Email = "anhVhn@gmail.com", Password = "098788865", Salt = "453426", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, DisabledAt = DateTime.Now, Status = 1, LockoutEnabled = false, TwoFactorEnabled = false, AccessFailedCount = 0, UserName = "qgggg", PhoneNumberConfirmed = false },
                 new User() { Id = "4", FirstName = "Vũ", LastName = "Tân", PhoneNumber = "0986007534", Description = "HR Manager, ZS Associates", Email = "Vuhoang@gmail.com", Password = "09878881243", Salt = "4234567", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, DisabledAt = DateTime.Now, Status = 1, LockoutEnabled = false, TwoFactorEnabled = false, AccessFailedCount = 0, UserName = "sdfgd", PhoneNumberConfirmed = false },
                 new User() { Id = "5", FirstName = "Ngô", LastName = "Minh Quang", PhoneNumber = "0986007600", Description = "Web developer", Email = "hoangAnh@gmail.com", Password = "0987888004234", Salt = "423875", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, DisabledAt = DateTime.Now, Status = 1, LockoutEnabled = false, TwoFactorEnabled = false, AccessFailedCount = 0, UserName = "qfsdfs", PhoneNumberConfirmed = false }
                 );
            context.Categories.AddOrUpdate(x => x.Id,
                new Category() { Id = "1", Name = "Công nghệ Khoa học máy tính", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, DisabledAt = DateTime.Now, Status = 1 },
                new Category() { Id = "2", Name = "Kinh doanh - khởi nghiệp", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, DisabledAt = DateTime.Now, Status = 1 },
                new Category() { Id = "3", Name = "Làm bếp", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, DisabledAt = DateTime.Now, Status = 1 },
                new Category() { Id = "4", Name = "Nghệ thuật", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, DisabledAt = DateTime.Now, Status = 1 },
                new Category() { Id = "5", Name = "Nhạc cụ", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, DisabledAt = DateTime.Now, Status = 1 },
                new Category() { Id = "6", Name = "Ngoại ngữ", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, DisabledAt = DateTime.Now, Status = 1 },
                new Category() { Id = "7", Name = "Kỹ năng lãnh đạo", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, DisabledAt = DateTime.Now, Status = 1 },
                new Category() { Id = "8", Name = "Kỹ năng mềm", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, DisabledAt = DateTime.Now, Status = 1 },
                new Category() { Id = "9", Name = "Thiết kế", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, DisabledAt = DateTime.Now, Status = 1 },
                new Category() { Id = "10", Name = "Đầu tư tài chính", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, DisabledAt = DateTime.Now, Status = 1 }
                );
            context.Teachers.AddOrUpdate(x => x.Id,
                new Teacher() { Id = "1", Name = "Trần Duy Thanh", Thumbnail = "https://cdn2.edumall.io/k-57e4def8ce4b145a1020dbf9/20181212-thanhtd23-121218/avatar_hahahahth.jpg", Description = "Chuyên gia hàng đầu công nghệ Spring hero bank" },
                new Teacher() { Id = "2", Name = "Phạm Thành Long", Thumbnail = "https://2sao.vietnamnetjsc.vn/images/2021/04/19/11/54/pham-thanh-long-02.jpg", Description = "CEO Công ty CP Tích Hợp Dịch Vụ Số thành lập từ 2008." },
                new Teacher() { Id = "3", Name = "Ms.Linh Vũ(Vũ Thùy Linh)", Thumbnail = "https://cdn1.edumall.io/320/k-577a160c047c994bb7e5b397/20180123-/co-linh-4-1.png", Description = "Giám đốc công ty TNHH đào tạo Lego." },
                new Teacher() { Id = "4", Name = "Vũ Tiến Thành", Thumbnail = "https://cdn1.edumall.io/320/k-5768aeb1047c995f75fdbf6b/20180719-/thanhvt.jpg", Description = "Thạc sĩ Vũ Tiến Thành, với kinh nghiệm trên 10 năm giảng dạy cho các học sinh, sinh viên, đã đào tạo nhiều lứa học sinh, sinh viên giỏi. Đạt danh hiệu thi đua các cấp." },
                new Teacher() { Id = "5", Name = "Dj MiE", Thumbnail = "https://spartabeerclub.vn/media/images/article/517/tieu-my.jpg", Description = "DJ Mie đến từ Đà Nẵng nổi tiếng với khả năng chơi nhạc hay cùng thân hình quyến rũ. Cô là nữ DJ tài năng nhất hiện nay. Cô là gương mặt quen thuộc tại Oneplus Rooftop Beer Club và Yo Yo Beer Garden. Theo đuổi dòng nhạc EDM khiến Mie thu về không ít fan hâm mộ. " },
                new Teacher() { Id = "6", Name = "Trần Thị Quỳnh", Thumbnail = "https://cdn1.edumall.io/320/k-57bd1aa7047c994a15e41aca/20171222-quynhtt201_1222/e9.jpg", Description = "Nhà sáng lập kiêm điều hành công ty Cổ phần đầu tư Quốc tế La Vita (La Vita Bakery). Hoa hậu Thể thao Việt Nam năm 2007. Từng là đại sứ kiêm phóng viên của Đài tiếng nói Việt Nam." },
                new Teacher() { Id = "7", Name = "Lê Thẩm Dương", Thumbnail = "https://cdn7.edumall.vn/uploads/images/instructors/le-tham-duong.png", Description = "TS. Lê Thẩm Dương được biết đến không chỉ là một giảng viên xuất sắc của Khoa Quản trị Kinh doanh, Đại học Ngân hàng TP. Hồ Chí Minh mà còn là một diễn giả chuyên nghiệp, một chuyên gia hàng đầu trong nhiều lĩnh vực đào tạo, hoạt động thực tiễn..." },
                new Teacher() { Id = "8", Name = "K Team", Thumbnail = "https://yt3.ggpht.com/ytc/AKedOLTbHH7PDB7YK1GZkZD1nbqRk5FpcTyiXbaNfeFumw=s48-c-k-c0x00ffffff-no-rj", Description = "Thư viện khóa học lập trình từ cơ bản đến nâng cao" },
                new Teacher() { Id = "9", Name = "Nguyễn Đức Việt", Thumbnail = "https://cdn1.edumall.io/320/k-57bd1aa7047c994a15e41aca/20181214-/1531371091918.png", Description = "Nguyễn Đức Việt, tốt nghiệp Đại học Bách khoa, khoa công nghệ thông tin. Với 10 năm kinh nghiệm giảng dạy, anh có hàng nghìn học viên đã tốt nghiệp và làm việc trong lĩnh vực thiết kế,đặc biệt là thiết kế website chuyên nghiệp." },
                new Teacher() { Id = "10", Name = "Asteria Đỗ", Thumbnail = "https://cdn1.edumall.io/320/k-57e4def8ce4b145a1020dbf9/20171228-/26024640_1904729586508729_445.jpg", Description = "Asteria đã từng sinh sống và làm việc tại Úc trong thời gian gần 10 năm, với bằng Bachelor of Engineering Second-class Honour Division 1 (Bằng Kỹ sư loại giỏi), bằng TESOL (Teaching English to Speakers of Other Languages) Grade A, và kinh nghiệm gần " },
                new Teacher() { Id = "11", Name = "Bùi Văn Nam", Thumbnail = "https://cdn1.edumall.io/320/k-5768aeb1047c995f75fdbf6b/20190615-/64868595_560844211110245_1438.jpg", Description = "Giám đốc Arena Thủ Đức, giảng viên/ chuyên gia đào tạo Blockchain cho các hội nghị quốc tế tại: Dubai, Singapore, Bangkok, Phompenh, Paris, Hà Nội, HCMC... từ 2015 đến nay. Đã đào tạo ra nhiều chuyên gia, triệu phú kiếm tiền từ lĩnh vực này." }
                );
            context.Levels.AddOrUpdate(x => x.Id,
                new Level() { Id = "0", Name = "Beginner" },
                new Level() { Id = "1", Name = "Middle" },
                new Level() { Id = "2", Name = "Master" }
                );
            context.Courses.AddOrUpdate(x => x.Id,
                new Course() { Id = "CRS_ad6f9", CategoryId = "1", Name = "Lập trình Java cơ bản", Description = "Thành thạo Java chỉ qua 1 khóa học", Detail = "Khóa học cung cấp trọn bộ kiến thức lập trình Java. Cung cấp kiến thức để tiếp cận lập trình Android. Có khả năng tiếp tục phát triển phần mềm Java nâng cao: Swing, kết nối cơ sở dữ liệu, Lập trình Android, Lập trình Kotlin...Tìm hiểu cơ bản về ngôn ngữ lập trình Java(Từ định nghĩa đến kiểu dữ liệu, biến, câu lệnh, mảng, chuỗi... cấu trúc điều khiển trong Java, phương thức, lớp....", Duration = 140000, LevelId = "0", Rating = 5, Thumbnail = "https://edumall.vn/_next/image?url=%2Fapi%2Fimageproxy%3Furl%3Dhttps%253A%252F%252Fcdn2.topica.vn%252F5a7a63749f7bfc459700033e%252Fproduct%252F603e3fea9a780e0025783b23&w=1920&q=50", Price = 10, TeacherId = "1", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, DisabledAt = DateTime.Now, Status = 1 },
                new Course() { Id = "CRS_ad6f2", CategoryId = "2", Name = "Phương pháp kinh doanh online hiệu quả cho sản phẩm", Description = "Với hơn 20 bài giảng, áp dụng cho sản phẩm 'đèn xông tinh dầu' thực tế, được hướng dẫn một cách hợp lý, xuyên suốt bởi chuyên gia marketing Vương Mạnh Hoàng - một giảng viên có hơn 10 năm kinh nghiệm làm việc trong lĩnh vực marketing online, sẽ giúp bạn nắm được và triển khai quảng cáo trên năm kênh marketing online thông dụng: SEO, facebook, Forum seeding, Email, Youtube, một cách bài bản.", Detail = "Marketing là một phần không thể thiếu giúp một doanh nghiệp có thể bán sản phẩm của mình. Đừng chần chừ gì nữa, hãy tham gia khoa học của chúng tôi, và bắt tay thực hiện chiến lược marketing của bạn ngay bây giờ!", Duration = 300000, LevelId = "1", Rating = 5, Thumbnail = "https://edumall.vn/_next/image?url=%2Fapi%2Fimageproxy%3Furl%3Dhttps%253A%252F%252Fcdn2.topica.vn%252F191ab4fd-9c62-4494-b209-51f86a3924d3%252Fproduct%252F613a2457e818b400255e33e7&w=1920&q=50", Price = 50, TeacherId = "2", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, DisabledAt = DateTime.Now, Status = 1 },
                new Course() { Id = "CRS_ad6f3", CategoryId = "3", Name = "Các món bún Việt Nam", Description = "Thành thạo nấu các hương vị bún của 3 miền ngay tại căn bếp nhà bạn", Detail = "Trong ẩm thực Việt Nam, bún là loại thực phẩm dạng sợi tròn, trắng mềm, được làm từ tinh bột gạo tẻ, tạo sợi qua khuôn và được luộc chín trong nước sôi. Là một nguyên liệu, thành phần chủ yếu để chế biến nhiều món ăn mà tên món ăn thường có chữ bún ở đầu (như bún cá, bún mọc, bún chả, bún thang, v.v.), bún là một trong những loại thực phẩm phổ biến nhất trong cả nước, chỉ xếp sau các món ăn dạng cơm, phở.", Duration = 230000, LevelId = "1", Rating = 4.5, Thumbnail = "https://edumall.vn/_next/image?url=%2Fapi%2Fimageproxy%3Furl%3Dhttps%253A%252F%252Fcdn2.topica.vn%252F191ab4fd-9c62-4494-b209-51f86a3924d3%252Fproduct%252F613821cee818b400255e2993&w=1920&q=50", Price = 10, TeacherId = "6", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, DisabledAt = DateTime.Now, Status = 1 },
                new Course() { Id = "CRS_ad6f4", CategoryId = "4", Name = "Nhập môn nhiếp ảnh", Description = "Thành thạo nhiếp ảnh chỉ qua 1 khóa học", Detail = "Nắm được các hệ thống thiết bị cơ bản trong nhiếp ảnh.", Duration = 20000, LevelId = "2", Rating = 4.5, Thumbnail = "https://edumall.vn/_next/image?url=%2Fapi%2Fimageproxy%3Furl%3Dhttps%253A%252F%252Fcdn2.topica.vn%252F5a7a63749f7bfc459700033e%252Fproduct%252F603e3fea9a780e0025783b23&w=1920&q=50", Price = 10, TeacherId = "4", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, DisabledAt = DateTime.Now, Status = 1 },
                new Course() { Id = "CRS_ad6f5", CategoryId = "8", Name = "Bí quyết giao tiếp để thành công", Description = "Bí quyết giao tiếp để thành công từ Tiến sĩ Lê Thẩm Dương.", Detail = "Hiểu được tầm quan trọng của việc xây dựng mối quan hệ: 'Giao tiếp hoặc là chết'. Biết được phương tiện, cơ sở của giao tiếp trong việc tạo dựng mối quan hệ. Nắm được các kỹ năng cơ bản của giao tiếp: kỹ năng nghe, nói, khen chê và phi ngôn ngữ", Duration = 20000, LevelId = "1", Rating = 4.6, Thumbnail = "https://edumall.vn/_next/image?url=%2Fapi%2Fimageproxy%3Furl%3Dhttps%253A%252F%252Fcdn2.topica.vn%252F5f7159b797b2783a258a1267%252Fproduct%252F60eecca42100810024e3d8ef&w=1920&q=50", Price = 12.89, TeacherId = "7", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, DisabledAt = DateTime.Now, Status = 1 },
                new Course() { Id = "CRS_ad6f6", CategoryId = "1", Name = "Khóa học Python từ Zero tới Hero", Description = "Làm chủ Python trong 4 tuần", Detail = "Khóa học cung cấp trọn bộ kiến thức từ cơ bản của lập trình Python, học viên có thể tạo ra một ứng dụng Python hoàn chỉnh sau khi hoàn thành ", Duration = 21600, LevelId = "2", Rating = 5, Thumbnail = "https://edumall.vn/_next/image?url=%2Fapi%2Fimageproxy%3Furl%3Dhttps%253A%252F%252Fcdn2.topica.vn%252F191ab4fd-9c62-4494-b209-51f86a3924d3%252Fproduct%252F6111592c779ec70024992494&w=1920&q=50", Price = 12.89, TeacherId = "8", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, DisabledAt = DateTime.Now, Status = 1 },
                new Course() { Id = "CRS_ad6f7", CategoryId = "9", Name = "Thiết kế UX/UI cho ứng dụng và website", Description = "1 Trang web xịn chắc chắn phải có giao diện đẹp và thân thiện với người dùng", Detail = "Nắm bắt nguyên tắc thiết kế UI, UX để tạo ra 1 giao diện website hơn cả ĐẸP", Duration = 21600, LevelId = "2", Rating = 5, Thumbnail = "https://edumall.vn/_next/image?url=%2Fapi%2Fimageproxy%3Furl%3Dhttps%253A%252F%252Fcdn2.topica.vn%252F191ab4fd-9c62-4494-b209-51f86a3924d3%252Fproduct%252F613b3be9e818b400255e37e2&w=1920&q=50", Price = 12.89, TeacherId = "9", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, DisabledAt = DateTime.Now, Status = 1 },
                new Course() { Id = "CRS_ad6f8", CategoryId = "6", Name = "Phát âm tiếng Anh và giao tiếp căn bản", Description = "Tiếng Anh thực sự khó nếu bạn không phát âm đúng", Detail = "Đến với khóa học, bạn sẽ được học kỹ về các yếu tố để có phát âm chuẩn tiếng Anh là khẩu hình và trọng âm chính xác.", Duration = 12000, LevelId = "0", Rating = 4.9, Thumbnail = "https://edumall.vn/_next/image?url=%2Fapi%2Fimageproxy%3Furl%3Dhttps%253A%252F%252Fcdn2.topica.vn%252F191ab4fd-9c62-4494-b209-51f86a3924d3%252Fproduct%252F61381f29e818b400255e2969&w=1920&q=50", Price = 30, TeacherId = "10", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, DisabledAt = DateTime.Now, Status = 1 },
                new Course() { Id = "CRS_ad6f1", CategoryId = "5", Name = "Ảo thuật với âm thanh cùng DJ số 1 Việt Nam", Description = " Khóa Học DJ trực tuyến sẽ giúp bạn trở thành 1 DJ Chuyên nghiệp", Detail = "Tham gia khóa học này bạn có thể tự tin làm nhạc cho các buổi tiệc của gia đình, bạn bè. Bạn có thể thoải mái làm chủ âm thanh cho các quán bar hay các sự kiện lớn nhỏ. Sử dụng thành thạo những chương trình ứng dụng hỗ trợ Serato DJ", Duration = 14000, LevelId = "2", Rating = 5, Thumbnail = "https://edumall.vn/_next/image?url=%2Fapi%2Fimageproxy%3Furl%3Dhttps%253A%252F%252Fcdn2.topica.vn%252F191ab4fd-9c62-4494-b209-51f86a3924d3%252Fproduct%252F613b3a25e818b400255e37c8&w=1920&q=50", Price = 13.89, TeacherId = "8", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, DisabledAt = DateTime.Now, Status = 1 },
                new Course() { Id = "CRS_ad6f0", CategoryId = "10", Name = "Công nghệ Blockchain và tiền kỹ thuật số", Description = "Mua bán thông minh với nhiều dòng tiền kĩ thuật số", Detail = "Nhận thức/ phân biệt được ngay các loại đồng tiền lâu đời và các đồng mới ra , phân biệt được ngay các sàn tài chính ảo và thực để tránh mất tiền khi đầu tư không đúng chỗ (tránh được các sự mời chào không đúng khi đã có kiến thức).", Duration = 21600, LevelId = "2", Rating = 4, Thumbnail = "https://edumall.vn/_next/image?url=%2Fapi%2Fimageproxy%3Furl%3Dhttps%253A%252F%252Fcdn2.topica.vn%252F191ab4fd-9c62-4494-b209-51f86a3924d3%252Fproduct%252F6111592c779ec70024992494&w=1920&q=50", Price = 12.89, TeacherId = "11", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, DisabledAt = DateTime.Now, Status = 1 }
                );
            context.Sections.AddOrUpdate(x => x.Id,
                new Section() { Id = "1", CourseId = "1", Name = "Giới thiệu Java", Type = 0, Content = "3gtOAlcovoQ", Duration = 550, Order = 1 },
                new Section() { Id = "2", CourseId = "1", Name = "Cài đặt môi trường Java", Type = 0, Content = "KjMRn1YQcLc", Duration = 860, Order = 2 },
                new Section() { Id = "3", CourseId = "1", Name = "Chương trình Java đầu tiên", Type = 0, Content = "jIQmebw9VaA", Duration = 598, Order = 3 },
                new Section() { Id = "4", CourseId = "1", Name = "Biến và kiểu dữ liệu trong Java ", Type = 1, Content = "<p>Trong chương n&agrave;y, ch&uacute;ng ta sẽ học biến v&agrave; kiểu dữ liệu trong java.</p><p>Trong java, biến l&agrave; t&ecirc;n của v&ugrave;ng nhớ được lưu trong bộ nhớ stack. <strong>C&oacute; 3 kiểu biến trong java</strong>, bao gồm biến cục bộ (hay c&ograve;n gọi l&agrave; biến local), biến to&agrave;n cục (biến instance) v&agrave; biến tĩnh(biến static).</p><p><strong>C&oacute; 2 kiểu dữ liệu trong java</strong>, đ&oacute; l&agrave; kiểu dữ liệu nguy&ecirc;n thủy (primitive) v&agrave; kiểu dữ liệu đối tượng.</p><h2>Biến trong java</h2><p><strong>Quy tắc đặt t&ecirc;n biến trong java:</strong></p><ul> <li>Chỉ được bắt đầu bằng một k&yacute; tự(chữ), hoặc một dấu gạch dưới(_), hoặc một k&yacute; tự dollar($)</li><li>T&ecirc;n biến kh&ocirc;ng được chứa khoảng trắng</li><li>Bắt đầu từ k&yacute; tự thứ hai, c&oacute; thể d&ugrave;ng k&yacute; tự(chữ), dấu gạch dưới(_), hoặc k&yacute; tự dollar($)</li><li>Kh&ocirc;ng được tr&ugrave;ng với c&aacute;c từ kh&oacute;a</li><li>C&oacute; ph&acirc;n biệt chữ hoa v&agrave; chữ thường</li></ul><h4>1. Biến local trong java</h4><ul> <li>Biến cục bộ được khai b&aacute;o trong c&aacute;c phương thức, h&agrave;m contructor hoặc trong c&aacute;c block.</li><li>Biến cục bộ được tạo b&ecirc;n trong c&aacute;c phương thức, contructor, block v&agrave; sẽ bị ph&aacute; hủy khi kết th&uacute;c c&aacute;c phương thức, contructor v&agrave; block.</li><li>Kh&ocirc;ng được sử dụng &ldquo;access modifier&rdquo; khi khai b&aacute;o biến cục bộ.</li><li>C&aacute;c biến cục bộ sẽ nằm tr&ecirc;n v&ugrave;ng bộ nhớ stack của bộ nhớ.</li><li>Bạn cần khởi tạo gi&aacute; trị mặc định cho biến cục bộ trước khi c&oacute; thể sử dụng.</li></ul><h4>2. Biến biến instance (biến to&agrave;n cục) trong java</h4><ul> <li>Biến instance được khai b&aacute;o trong một lớp(class), b&ecirc;n ngo&agrave;i c&aacute;c phương thức, constructor v&agrave; c&aacute;c block.</li><li>Biến instance được lưu trong bộ nhớ heap.</li><li>Biến instance được tạo khi một đối tượng được tạo bằng việc sử dụng từ kh&oacute;a &ldquo;new&rdquo; v&agrave; sẽ bị ph&aacute; hủy khi đối tượng bị ph&aacute; hủy.</li><li>Biến instance c&oacute; thể được sử dụng bởi c&aacute;c phương thức, constructor, block, ... Nhưng n&oacute; phải được sử dụng th&ocirc;ng qua một đối tượng cụ thể.</li><li>Bạn được ph&eacute;p sử dụng &quot;access modifier&quot; khi khai b&aacute;o biến instance, mặc định l&agrave; &quot;default&quot;.</li><li>Biến instance c&oacute; gi&aacute; trị mặc định phụ thuộc v&agrave;o kiểu dữ liệu của n&oacute;. V&iacute; dụ nếu l&agrave; kiểu int, short, byte th&igrave; gi&aacute; trị mặc định l&agrave; 0, kiểu double th&igrave; l&agrave; 0.0d, ... V&igrave; vậy, bạn sẽ kh&ocirc;ng cần khởi tạo gi&aacute; trị cho biến instance trước khi sử dụng.</li><li>B&ecirc;n trong class m&agrave; bạn khai b&aacute;o biến instance, bạn c&oacute; thể gọi n&oacute; trực tiếp bằng t&ecirc;n khi sử dụng ở khắp nới b&ecirc;n trong class đ&oacute;.</li></ul><h4>3. Biến static trong java</h4><ul> <li>Biến static được khai b&aacute;o trong một class với từ kh&oacute;a &quot;static&quot;, ph&iacute;a b&ecirc;n ngo&agrave;i c&aacute;c phương thức, constructor v&agrave; block.</li><li>Sẽ chỉ c&oacute; duy nhất một bản sao của c&aacute;c biến static được tạo ra, d&ugrave; bạn tạo bao nhi&ecirc;u đối tượng từ lớp tương ứng.</li><li>Biến static được lưu trữ trong bộ nhớ static ri&ecirc;ng.</li><li>Biến static được tạo khi chương tr&igrave;nh bắt đầu chạy v&agrave; chỉ bị ph&aacute; hủy khi chương tr&igrave;nh dừng.</li><li>Gi&aacute; trị mặc định của biến static phụ thuộc v&agrave;o kiểu dữ liệu bạn khai b&aacute;o tương tự biến instance.</li><li>Biến static được truy cập th&ocirc;ng qua t&ecirc;n của class chứa n&oacute;, với c&uacute; ph&aacute;p: TenClass.tenBien.</li><li>Trong class, c&aacute;c phương thức sử dụng biến static bằng c&aacute;ch gọi t&ecirc;n của n&oacute; khi phương thức đ&oacute; cũng được khai b&aacute;o với từ kh&oacute;a &quot;static&quot;.</li></ul><h2>C&aacute;c kiểu dữ liệu trong java</h2><p>Trong Java, kiểu dữ liệu được chia th&agrave;nh hai loại:</p><ul> <li>C&aacute;c kiểu dữ liệu nguy&ecirc;n thủy</li><li>C&aacute;c kiểu dữ liệu đối tượng</li></ul><hr><h4>1. Kiễu dữ liệu nguy&ecirc;n thủy</h4><p>Java cung cấp c&aacute;c kiểu dữ liệu cơ bản như sau:</p><table> <tbody> <tr> <td><strong>byte</strong></td><td>D&ugrave;ng để lưu dữ liệu kiểu số nguy&ecirc;n c&oacute; k&iacute;ch thước một byte (8 b&iacute;t). Phạm vi biểu diễn gi&aacute; trị từ -128 đến 127. Gi&aacute; trị mặc định l&agrave; 0.</td></tr><tr> <td><strong>char</strong></td><td>D&ugrave;ng để lưu dữ liệu kiểu k&iacute; tự hoặc số nguy&ecirc;n kh&ocirc;ng &acirc;m c&oacute; k&iacute;ch thước 2 byte (16 b&iacute;t). Phạm vi biểu diễn gi&aacute; trị từ 0 đến u\ffff. Gi&aacute; trị mặc định l&agrave; 0.</td></tr><tr> <td><strong>boolean</strong></td><td>D&ugrave;ng để lưu dữ liệu chỉ c&oacute; hai trạng th&aacute;i đ&uacute;ng hoặc sai (độ lớn chỉ c&oacute; 1 b&iacute;t). Phạm vi biểu diễn gi&aacute; trị l&agrave;{&ldquo;True&rdquo;, &ldquo;False&rdquo;}. Gi&aacute; trị mặc định l&agrave; False.</td></tr><tr> <td><strong>short</strong></td><td>D&ugrave;ng để lưu dữ liệu c&oacute; kiểu số nguy&ecirc;n, k&iacute;ch cỡ 2 byte (16 b&iacute;t). Phạm vi biểu diễn gi&aacute; trị từ - 32768 đến 32767. Gi&aacute; trị mặc định l&agrave; 0.</td></tr><tr> <td><strong>int</strong></td><td>D&ugrave;ng để lưu dữ liệu c&oacute; kiểu số nguy&ecirc;n, k&iacute;ch cỡ 4 byte (32 b&iacute;t). Phạm vi biểu diễn gi&aacute; trị từ -2,147,483,648 đến 2,147,483,647. Gi&aacute; trị mặc định l&agrave; 0.</td></tr><tr> <td><strong>long</strong></td><td>D&ugrave;ng để lưu dữ liệu c&oacute; kiểu số nguy&ecirc;n c&oacute; k&iacute;ch thước l&ecirc;n đến 8 byte. Gi&aacute; trị mặc định l&agrave; 0L.</td></tr><tr> <td><strong>float</strong></td><td>D&ugrave;ng để lưu dữ liệu c&oacute; kiểu số thực, k&iacute;ch cỡ 4 byte (32 b&iacute;t). Gi&aacute; trị mặc định l&agrave; 0.0F.</td></tr><tr> <td><strong>double</strong></td><td>D&ugrave;ng để lưu dữ liệu c&oacute; kiểu số thực c&oacute; k&iacute;ch thước l&ecirc;n đến 8 byte. Gi&aacute; trị mặc định l&agrave; 0.00D<br></td></tr></tbody></table><h4>2. Kiểu dữ liệu đối tượng</h4><p>Trong java c&oacute; 3 kiểu dữ liệu đối tượng:</p><table> <tbody> <tr> <td><strong>Array</strong></td><td>Một mảng của c&aacute;c dữ liệu c&ugrave;ng kiểu.</td></tr><tr> <td><strong>class</strong></td><td>Dữ liệu kiểu lớp đối tượng do người d&ugrave;ng định nghĩa. Chứa tập c&aacute;c thuộc t&iacute;nh v&agrave; phương thức..</td></tr><tr> <td><strong>interface</strong></td><td>Dữ liệu kiểu lớp giao tiếp do người d&ugrave;ng định nghĩa. Chứa c&aacute;c phương thức của giao tiếp.</td></tr></tbody></table>", Duration = 598, Order = 4 },
                new Section() { Id = "5", CourseId = "4", Name = "Tại sao chúng ta cần mua máy ảnh?", Type = 0, Content = "z1zWvtRucn0", Duration = 276, Order = 1 },
                new Section() { Id = "6", CourseId = "4", Name = "Tìm hiểu về khẩu độ", Type = 0, Content = "PwrA7yFo7eQ", Duration = 300, Order = 2 },
                new Section() { Id = "7", CourseId = "4", Name = "Tìm hiểu về Tốc độ chụp", Type = 0, Content = "Tdz_4PZtqkE", Duration = 265, Order = 3 },
                new Section() { Id = "8", CourseId = "4", Name = "Tìm hiểu về Độ nhạy sáng ISO", Type = 0, Content = "2-vykRIVdyM", Duration = 329, Order = 4 },
                new Section() { Id = "9", CourseId = "2", Name = "Hướng dẫn kinh doanh online cho người mới bắt đầu", Type = 0, Content = "8EJdIiSk05I", Duration = 1666, Order = 1 },
                new Section() { Id = "10", CourseId = "2", Name = "TOP 7 PHƯƠNG PHÁP ĐỂ VIỆC KINH DOANH ONLINE CỦA BẠN TRỞ NÊN DỄ DÀNG HƠN", Type = 1, Content = "<div><label>TOP 7 PHƯƠNG PH&Aacute;P ĐỂ VIỆC KINH DOANH ONLINE CỦA BẠN TRỞ N&Ecirc;N DỄ D&Agrave;NG HƠN</label></div><div> <p><em><strong>TOP 7 phương ph&aacute;p để việc kinh doanh ****** của bạn trở n&ecirc;n dễ d&agrave;ng hơn.</strong></em></p><p>Nhờ v&agrave;o sự ph&aacute;t triển của c&ocirc;ng nghệ hiện đại, nhu cầu mua sắm của *** người ng&agrave;y c&agrave;** gia tăng v&agrave; mong muốn rằng sẽ tiết kiệm được nhiều thời gian, c&ocirc;ng sức trong việc lựa chọn h&agrave;ng h&oacute;a của kh&aacute;ch h&agrave;ng. Tuy nhi&ecirc;n, c&oacute; rất nhiều người chỉ cho rằng <em>kinh ***** online</em> l&agrave; đăng v&agrave; b&aacute;n h&agrave;ng tr&ecirc;n mạng, kh&aacute;ch h&agrave;ng sẽ tự động t&igrave;m kiếm tới m&igrave;nh. Như** bạn phải hiểu một điều rằng, người sử dụng họ rất th&ocirc;ng minh v&agrave; họ phải thực sự đắn đo, t&igrave;m hiểu hay soi x&eacute;t thật kỹ trước khi họ bỏ chi ph&iacute; cho những sản phẩm ấy. Vậy phải l&agrave;m thế n&agrave;o để những sản phẩm của bạn c&oacute; thể đem đến với <em>kh&aacute;ch h&agrave;ng tiềm năng</em>, cũng như được mọi người tin d&ugrave;ng? H&atilde;y c&ugrave;ng&nbsp;<em>Marketing To&agrave;n Cầu</em> t&igrave;m hiểu vấn đề n&agrave;y qua b&agrave;i viết dưới đ&acirc;y nh&eacute;!</p><p><strong>1. X&acirc;y dựng website ri&ecirc;ng</strong></p><p>Website được coi l&agrave; danh thiếp điện tử tr&ecirc;n m&ocirc;i trường internet của doanh nghiệp. C&ocirc;ng cụ n&agrave;y trở th&agrave;nh &ldquo;tử huyệt&rdquo; nếu doanh nghiệp ph&aacute;t triển theo kinh doanh online. Kh&aacute;ch h&agrave;ng hoặc đối t&aacute;c sẽ cảm thấy ** t&acirc;m hơn nếu doanh nghiệp của bạn c&oacute; một&nbsp;<em>website đẹp</em>, logic, đầy đủ những th&ocirc;ng tin cần thiết. Kh&ocirc;ng những thế, bản th&acirc;n Doanh nghiệp cũng sẽ thấy tự tin hơn nếu đang sở hữu *** m&igrave;nh một website đẹp, đầy đủ t&iacute;nh năng theo mong muốn, dễ sử dụng v&agrave; t&ugrave;y chỉnh.&nbsp;</p><p><br></p><p><strong>2. C&ocirc;ng cụ thiết kế v&agrave; chỉnh sửa ảnh</strong></p><p>Việc tự m&igrave;nh thực hiện c&aacute;c hoạt động truyền th&ocirc;** bao gồm việc tự m&igrave;nh thiết kế v&agrave; chỉnh sửa c&aacute;c bức ảnh để l&agrave;m nội dung cho website *** fanpage của m&igrave;nh. Nếu bạn kh&ocirc;ng phải l&agrave; một designer, bạn sẽ gặp mu&ocirc;n v&agrave;n kh&oacute; khăn trong việc sử dụng phần mềm chuy&ecirc;n nghiệp. Ch&iacute;nh v&igrave; vậy c&aacute;c c&ocirc;ng cụ thiết kế v&agrave; chỉnh sửa ảnh (miễn ph&iacute;) lu&ocirc;n l&agrave; lựa chọn th&ocirc;ng minh d&agrave;nh cho bạn. Hiện *** c&oacute; rất nhiều c&aacute;c phần mềm thực hiện trong lĩnh vực n&agrave;y, v&iacute; dụ như phần mềm Photoscape, Picasa&hellip; cho đến c&aacute;c c&ocirc;ng cụ trực tuyến như ***** hay Designbold của Việt Nam,...</p><p><strong>3. Mạng x&atilde; hội</strong></p><p>Ch&uacute;ng ** đang sống trong thời kỳ &ldquo;thống trị&rdquo; của mạng x&atilde; hội, ti&ecirc;u biểu l&agrave; ******** v&agrave; Youtube. Ngo&agrave;i c&aacute;c t&ecirc;n tuổi quốc tế, tại Việt Nam c&ograve;n c&oacute; một số mạng x&atilde; hội đ&igrave;nh đ&aacute;m kh&aacute;c như Zalo, Muvik, tik tok,.. d&agrave;nh cho độ tuổi teen. Nếu kh&aacute;ch h&agrave;ng mục ti&ecirc;u của bạn l&agrave; những người trẻ với phong c&aacute;ch sống hiện đại, bạn kh&oacute; c&oacute; thể bỏ qua k&ecirc;nh tiếp cận n&agrave;y. Điều tốt nhất l&agrave; bạn cần x&acirc;y dựng thương hiệu cho doanh nghiệp của m&igrave;nh th&ocirc;ng *** mạng x&atilde; hội. Đ&acirc;y cũng l&agrave; nền tảng x&acirc;y dựng cộng đồ** v&agrave; chăm s&oacute;c kh&aacute;ch h&agrave;ng tốt nhất khi mọi thứ đều c&oacute; thể tư vấn v&agrave; gọi điện trực tuyến miễn ph&iacute;.</p><p><strong>4. C&ocirc;** cụ gửi email marketing</strong></p><p>Một ***** những hoạt độ** chăm s&oacute;c kh&aacute;ch h&agrave;ng v&agrave; chuyển đổi &ldquo;người tham quan&rdquo; th&agrave;** &ldquo;đơn h&agrave;ng&rdquo; l&agrave; h&igrave;nh thức th&ocirc;** qua email. Doanh nghiệp c&oacute; thể gửi th&ocirc;ng tin về c&aacute;c chương tr&igrave;nh, ưu đ&atilde;i hoặc c&aacute;c t&agrave;i liệu hữu &iacute;ch qua email của kh&aacute;ch h&agrave;ng. Thống k&ecirc; cho thấy, email l&agrave; k&ecirc;nh truyền th&ocirc;ng tiết kiệm chi ph&iacute; nhất như: chi ph&iacute; bỏ ** thấp gần như nhất nhưng tỷ lệ chuyển đổi lại kh&aacute; cao. Tất nhi&ecirc;n, hoạt động email marketing cũ** cần c&oacute; kịch bản v&agrave; triển khai từng bước. Những nền tả** gửi ***** phổ biến nhất l&agrave; MailChimp, GetResponse&hellip; đều cho ph&eacute;p gửi miễn ph&iacute; một số lượng email n&agrave;o đ&oacute; h&agrave;ng th&aacute;ng. C&aacute;c g&oacute;i trả tiền cũ** tương đối rẻ v&agrave; c&oacute; th&ecirc;m nhiều t&iacute;nh năng hấp dẫn như t&ugrave;y chỉnh giao diện email, b&aacute;o c&aacute;o chi tiết c&aacute;c chiến dịch gửi&hellip;</p><p><strong>5. C&ocirc;ng cụ đo lường website</strong></p><p>L&agrave; nh&agrave; **** doanh, c&aacute;c giảng vi&ecirc;n cũng cần biết một số c&aacute;ch thức đo lườ** hiệu quả của c&aacute;c hoạt động truyền th&ocirc;ng, trong đ&oacute; đo lường website l&agrave; một trong những việc bắt buộc phải l&agrave;m. C&aacute;c th&ocirc;ng số cơ bản của hoạt động đo lường website bao gồm: số lượng phi&ecirc;n truy cập h&agrave;ng th&aacute;ng, thời gian trung b&igrave;nh tr&ecirc;n trang, tỷ lệ quay lại/truy cập mới, tỷ lệ tho&aacute;t sau lần truy cập đầu ti&ecirc;n, ph&acirc;n luồng truy cập, nguồn truy cập. Bạn cần nắm được c&aacute;c th&ocirc;ng số cơ bản n&agrave;y để c&oacute; những biện ph&aacute;p cải thiện hoạt động truyền th&ocirc;ng nhằm n&acirc;ng cao hiệu quả **** doanh.&nbsp;</p><p><strong>6. C&ocirc;ng cụ khảo s&aacute;t &yacute; kiến kh&aacute;ch h&agrave;ng trực tuyến</strong></p><p>Khi bạn cần thực hiện khảo s&aacute;t, một số c&ocirc;ng cụ đơn giản sẽ gi&uacute;p bạn thực hiện việc n&agrave;y nhanh hơn, chuy&ecirc;n nghiệp hơn: Google Docs, SurveyMonkey. Ch&uacute;ng đ&atilde; t&iacute;ch hợp sẵn c&aacute;c dạng c&acirc;u hỏi khảo s&aacute;t phổ biến (lựa chọn nhiều đ&aacute;p &aacute;n, lựa chọn 1 đ&aacute;p &aacute;n, thang điểm đ&aacute;nh gi&aacute;, lưới c&acirc;u hỏi, c&acirc;u hỏi mở&hellip;) v&agrave; thống k&ecirc; kết quả dưới dạng đồ thị. V&igrave; vậy bạn sẽ tiết kiệm được rất nhiều thời gian **** v&igrave; phải gọi điện trực tiếp cho từng người để lấy &yacute; kiến.</p><p><strong>7. C&ocirc;ng cụ hỗ trợ SEO</strong></p><p>SEO l&agrave; hoạt động cần thiết đối với mọi đơn vị kinh doanh dựa tr&ecirc;n nền tảng ch&iacute;nh l&agrave; website. N&oacute;i một c&aacute;** đơn giản, SEO l&agrave; c&aacute;** thức t&aacute;c độ** v&agrave;o website (<em>on-page SEO</em> như tối ưu kỹ thuật, tối ưu nội dung) v&agrave; ph&aacute;t t&aacute;n website đ&uacute;ng c&aacute;ch (<em>off-page SEO</em> như: chia sẻ link, gắn backlink&hellip;) nhằm tối ưu vị tr&iacute; của website tr&ecirc;n c&ocirc;ng cụ t&igrave;m kiếm (hiện nay phổ biến nhất l&agrave; Google). Mục ti&ecirc;u của hoạt động n&agrave;y l&agrave; nhằm đưa ******* của doanh nghiệp l&ecirc;n những vị tr&iacute; tốt nhất tr&ecirc;n ****** tương ứng với c&aacute;c từ kh&oacute;a (keywords) m&agrave; người d&ugrave;** t&igrave;m kiếm. Một số SEO Tools điển h&igrave;nh l&agrave; Google Analytic, webmaster Tool, SEO doctor, Rank tracker&hellip; sẽ gi&uacute;p c&aacute;c chủ ***** nghiệp dễ d&agrave;ng hơn trong việc tối ưu website của m&igrave;nh.</p></div>", Duration = 0, Order = 2 },
                new Section() { Id = "11", CourseId = "6", Name = "Giới thiệu ngôn ngữ lập trình Python", Type = 0, Content = "NZj6LI5a9vc", Duration = 764, Order = 1 },
                new Section() { Id = "12", CourseId = "6", Name = "Cài đặt môi trường Python", Type = 0, Content = "jf-q_dG8WzI", Duration = 375, Order = 2 }

                );
            context.Orders.AddOrUpdate(x => x.Id,
                new Order() { Id = "1", UserId = "1", TotalPrice = "60", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, DisabledAt = DateTime.Now, Status = 1 },
                new Order() { Id = "2", UserId = "2", TotalPrice = "60", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, DisabledAt = DateTime.Now, Status = 1 },
                new Order() { Id = "3", UserId = "3", TotalPrice = "60", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, DisabledAt = DateTime.Now, Status = 1 },
                new Order() { Id = "4", UserId = "4", TotalPrice = "60", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, DisabledAt = DateTime.Now, Status = 1 },
                new Order() { Id = "5", UserId = "5", TotalPrice = "60", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, DisabledAt = DateTime.Now, Status = 1 }
                );
            context.OrderDetails.AddOrUpdate(x => new { x.OrderId, x.CourseId },
                new OrderDetail() { OrderId = "1", CourseId = "1", UnitPrice = 10 },
                new OrderDetail() { OrderId = "1", CourseId = "2", UnitPrice = 50 },
                new OrderDetail() { OrderId = "2", CourseId = "1", UnitPrice = 10 },
                new OrderDetail() { OrderId = "2", CourseId = "2", UnitPrice = 50 },
                new OrderDetail() { OrderId = "3", CourseId = "1", UnitPrice = 10 },
                new OrderDetail() { OrderId = "3", CourseId = "2", UnitPrice = 50 },
                new OrderDetail() { OrderId = "4", CourseId = "1", UnitPrice = 10 },
                new OrderDetail() { OrderId = "4", CourseId = "2", UnitPrice = 50 },
                new OrderDetail() { OrderId = "5", CourseId = "1", UnitPrice = 10 },
                new OrderDetail() { OrderId = "5", CourseId = "2", UnitPrice = 50 }
                );
            context.UserCourses.AddOrUpdate(x => new { x.UserId, x.CourseId },
                new UserCourse() { UserId = "1", CourseId = "1", Grade = "40", IsFinished = false },
                new UserCourse() { UserId = "1", CourseId = "2", Grade = "40", IsFinished = true },
                new UserCourse() { UserId = "2", CourseId = "1", Grade = "40", IsFinished = false },
                new UserCourse() { UserId = "2", CourseId = "2", Grade = "50", IsFinished = true }
                );
            context.UserSections.AddOrUpdate(x => new { x.UserId, x.SectionId },
                new UserSection() { UserId = "1", SectionId = "1", PausedAt = "550", IsFinished = true },
                new UserSection() { UserId = "1", SectionId = "2", PausedAt = "860", IsFinished = true },
                new UserSection() { UserId = "1", SectionId = "3", PausedAt = "550", IsFinished = false }
                );
            //context.Roles.AddOrUpdate(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
            //{
            //    Name = "Admin1"
            //});
            //context.Roles.AddOrUpdate(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
            //{
            //    Name = "User1"
            //});
            //context.Roles.AddOrUpdate(new Microsoft.AspNet.Identity.EntityFramework.IdentityRole()
            //{
            //    Name = "Customer1"
            //});
            context.SaveChanges();
        }
    }
}
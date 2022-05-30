namespace FCourse.Migrations
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
                 new User() { Id = "1", FirstName = "Vũ", LastName = "Anh", PhoneNumber = "0321154356", Description = "Web developer", Email = "Jimmianh1807@gmail.com", PasswordHash = "0987888008", Salt = "423425", Role = 1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, DisabledAt = DateTime.Now, Status = 1 },
                 new User() { Id = "2", FirstName = "Nguyễn", LastName = "Tân", PhoneNumber = "0986007605", Description = "iMBA graduate, University of Illinois Gies College of Business", Email = "Jimmianh@gmail.com", PasswordHash = "0987888007", Salt = "423325", Role = 1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, DisabledAt = DateTime.Now, Status = 1 },
                 new User() { Id = "3", FirstName = "Hoàng", LastName = "Anh", PhoneNumber = "0986007606", Description = "Student who obtained a Professional Certificate in IBM Data Science", Email = "anhVhn@gmail.com", PasswordHash = "098788865", Salt = "453426", Role = 1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, DisabledAt = DateTime.Now, Status = 1 },
                 new User() { Id = "4", FirstName = "Vũ", LastName = "Tân", PhoneNumber = "0986007534", Description = "HR Manager, ZS Associates", Email = "Vuhoang@gmail.com", PasswordHash = "09878881243", Salt = "4234567", Role = 0, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, DisabledAt = DateTime.Now, Status = 1 },
                 new User() { Id = "5", FirstName = "Ngô", LastName = "Minh Quang", PhoneNumber = "0986007600", Description = "Web developer", Email = "hoangAnh@gmail.com", PasswordHash = "0987888004234", Salt = "423875", Role = 1, CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, DisabledAt = DateTime.Now, Status = 1 }
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
                new Teacher() { Id = "1", Name = "Trần Duy Thanh", Thumbnail = "https://cdn2.edumall.io/k-57e4def8ce4b145a1020dbf9/20181212-thanhtd23-121218/avatar_hahahahth.jpg", Description = "Chuyên gia đầu hàng công nghệ Spring hero bank"}
                );
            context.Levels.AddOrUpdate(x => x.Id,
                new Level() {Id = "0", Name = "Beginner"},
                new Level() {Id = "1", Name = "Middle"},
                new Level() {Id = "2", Name = "Master"}
                );
            context.Courses.AddOrUpdate(x => x.Id,
                new Course() { Id = "1", CategoryId = "1", Name = "Lập trình Java cơ bản", Description = "Thành thạo Java chỉ qua 1 khóa học", Detail = "Khóa học cung cấp trọn bộ kiến thức lập trình Java. Cung cấp kiến thức để tiếp cận lập trình Android. Có khả năng tiếp tục phát triển phần mềm Java nâng cao: Swing, kết nối cơ sở dữ liệu, Lập trình Android, Lập trình Kotlin...Tìm hiểu cơ bản về ngôn ngữ lập trình Java(Từ định nghĩa đến kiểu dữ liệu, biến, câu lệnh, mảng, chuỗi... cấu trúc điều khiển trong Java, phương thức, lớp....", Duration = 140000, LevelId = "0", Thumbnail = "https://edumall.vn/_next/image?url=%2Fapi%2Fimageproxy%3Furl%3Dhttps%253A%252F%252Fcdn2.topica.vn%252F5a7a63749f7bfc459700033e%252Fproduct%252F603e3fea9a780e0025783b23&w=1920&q=50", Price = 10, TeacherId = "1", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, DisabledAt = DateTime.Now, Status = 1 }
                );
            context.Sections.AddOrUpdate(x => x.Id,
                new Section() { Id = "1", CourseId = "1", Name = "Giới thiệu Java", Type = 0, Content = "3gtOAlcovoQ", Duration = 550, Order = 1 }
                );
            context.Orders.AddOrUpdate(x => x.Id,
                new Order() { Id = "1", UserId = "1", TotalPrice = "1000", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now, DisabledAt = DateTime.Now, Status = 1 }
                );
            context.OrderDetails.AddOrUpdate(x => x.OrderId,
                new OrderDetail() { OrderId = "1", CourseId = "1", UnitPrice = 1000}
                );
            context.UserCourses.AddOrUpdate(x => x.UserId,
                new UserCourse() { UserId = "1", CourseId = "1", Grade = "50", IsFinished = true }
                );
            context.UserSections.AddOrUpdate(x => x.UserId,
                new UserSection() { UserId = "1", SectionId = "1", PausedAt = "550", IsFinished = true }
                );
        }
    }
}

namespace BookManager.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Spatial;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Book")]
    public partial class Book
    {
        public int ID { get; set; }

        [Column(TypeName = "ntext")]
        [Required(ErrorMessage = "Không Để Trống")]
        [MaxLength(100, ErrorMessage = "Không Qúa 100 Kí Tự")]
        public string Title { get; set; }

        [Column(TypeName = "ntext")]
        [Required(ErrorMessage = "Không Để Trống")]
        [MaxLength(30, ErrorMessage = "Không Qúa 30 Kí Tự")]
        public string Author { get; set; }

        [Column(TypeName = "ntext")]
        [Required(ErrorMessage = "Không Để Trống")]
        public string Image { get; set; }

        [Range(1000, 1000000, ErrorMessage = "Giá Từ 1.000 - 1.000.000 VNĐ")]
        [Required(ErrorMessage = "Không Để Trống")]
        public int Price { get; set; }

        [Column(TypeName = "ntext")]
        [Required(ErrorMessage = "Không Để Trống")]
        public string Desciption { get; set; }
    }
}

using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

public class Kullanici : IdentityUser
{
    [Required(ErrorMessage = "Ad alanı zorunludur.")]
    [StringLength(50, ErrorMessage = "Ad en fazla 50 karakter olabilir.")]
    public string Ad { get; set; }

    [Required(ErrorMessage = "Soyad alanı zorunludur.")]
    [StringLength(50, ErrorMessage = "Soyad en fazla 50 karakter olabilir.")]
    public string Soyad { get; set; }

    [Required(ErrorMessage = "Doğum tarihi alanı zorunludur.")]
    [DataType(DataType.Date)]
    public DateTime DogumTarihi { get; set; }

    [Required(ErrorMessage = "Telefon numarası zorunludur.")]
    [Phone(ErrorMessage = "Geçerli bir telefon numarası girin.")]
    [StringLength(15, ErrorMessage = "Telefon numarası en fazla 15 karakter olabilir.")]
    public string TelefonNumarasi { get; set; }

    [Required(ErrorMessage = "Adres alanı zorunludur.")]
    [StringLength(500, ErrorMessage = "Adres en fazla 500 karakter olabilir.")]
    [DataType(DataType.MultilineText)]
    public string Adres { get; set; }
}

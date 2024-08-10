
using System.ComponentModel.DataAnnotations;

namespace maga.Bussines
{
    public class UserDto
    {
        public ulong id { get; set; }
        public string name { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;
        public DateTime birthDate { get; set; } = DateTime.Now;
        public string familyNickName { get; set; } = string.Empty;
        public string phone { get; set; } = string.Empty;
        public byte state { get; set; }
        public byte isAdmin { get; set; }
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public DateTime creationDate { get; set; } = DateTime.Now;
        public DateTime updatedDate { get; set; } = DateTime.Now;
        public ulong idFamily { get; set; }
    }

    public class UserToShow
    {
        public ulong id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [RegularExpression(@"^[A-Za-z ]+$", ErrorMessage = "El nombre debe contener solo letras y espacios")]
        [StringLength(20, ErrorMessage = "El nombre no puede tener más de 20 caracteres")]
        public string name { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [RegularExpression(@"^[A-Za-z ]+$", ErrorMessage = "El nombre debe contener solo letras y espacios")]
        [StringLength(20, ErrorMessage = "El apellido no puede tener más de 20 caracteres")]
        public string lastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        public DateTime birthDate { get; set; } = DateTime.Now;
        public string familyNickName { get; set; } = string.Empty;

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "El número telefónico no es válido")]
        [StringLength(10, ErrorMessage = "El número telefónico no puede tener más de 10 caracteres")]
        public string phone { get; set; } = string.Empty;
        public byte state { get; set; }
        public byte isAdmin { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [RegularExpression(@"^[\w\.-]+@[\w\.-]+\.\w{2,4}$", ErrorMessage = "Debe ser un correo electrónico válido")]
        [StringLength(50, ErrorMessage = "El correo electrónico no puede tener más de 50 caracteres")]
        public string email { get; set; } = string.Empty;
        public ulong idFamily { get; set; }
    }

    public class UserToAdd
    {

        public ulong id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [RegularExpression(@"^[A-Za-z ]+$", ErrorMessage = "El nombre debe contener solo letras y espacios")]
        [StringLength(20, ErrorMessage = "El nombre no puede tener más de 20 caracteres")]
        public string name { get; set; } = string.Empty;

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [RegularExpression(@"^[A-Za-z ]+$", ErrorMessage = "El nombre debe contener solo letras y espacios")]
        [StringLength(20, ErrorMessage = "El apellido no puede tener más de 20 caracteres")]
        public string lastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha de nacimiento es obligatoria")]
        public DateTime birthDate { get; set; } = DateTime.Now;
        public string familyNickName { get; set; } = string.Empty;

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [RegularExpression(@"^\+?[1-9]\d{1,14}$", ErrorMessage = "El número telefónico no es válido")]
        [StringLength(10, ErrorMessage = "El número telefónico no puede tener más de 10 caracteres")]
        public string phone { get; set; } = string.Empty;
        public byte isAdmin { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [RegularExpression(@"^[\w\.-]+@[\w\.-]+\.\w{2,4}$", ErrorMessage = "Debe ser un correo electrónico válido")]
        [StringLength(50, ErrorMessage = "El correo electrónico no puede tener más de 50 caracteres")]
        public string email { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [MinLength(8, ErrorMessage = "La contraseña no puede tener menos de 8 caracteres")]
        public string password { get; set; } = string.Empty;
        public ulong idFamily { get; set; }

        [Required(ErrorMessage = "El código de verificación es obligatorio")]
        [StringLength(6, ErrorMessage = "El código de verificación no puede tener más de 6 caracteres")]
        public string verificationCode { get; set; } = string.Empty;
    }

    public class ResponseAddOrUpdate<T> where T : class
    {
        public T? identity { get; set; }
        public bool created { get; set; } = true;
    }

    public class RequestUpdatePassword
    {
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public string password { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña nueva es obligatoria")]
        [MinLength(8, ErrorMessage = "La contraseña no puede tener menos de 8 caracteres")]
        public string passwordNew { get; set; } = string.Empty;
    }

    public class RequestRecoveryPassword
    {
        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [RegularExpression(@"^[\w\.-]+@[\w\.-]+\.\w{2,4}$", ErrorMessage = "Debe ser un correo electrónico válido")]
        [StringLength(50, ErrorMessage = "El correo electrónico no puede tener más de 50 caracteres")]
        public string email { get; set; } = string.Empty;

        [Required(ErrorMessage = "El código de verificación es obligatorio")]
        public string code { get; set; } = string.Empty;

        [Required(ErrorMessage = "La contraseña nueva es obligatoria")]
        [MinLength(8, ErrorMessage = "La contraseña no puede tener menos de 8 caracteres")]
        public string passwordNew { get; set; } = string.Empty;
    }
}

# Hayvan Barınağı Web Projesi

Bu proje, **Mert Kan** tarafından, **Sakarya Üniversitesi Yaz Okulu 2023 Web Programlama dersi** kapsamında geliştirilmiştir. Proje, **hayvan barınaklarının hayvan kabulü** ve **sahiplendirme süreçlerini** kolaylaştırmayı amaçlayan bir web uygulamasıdır.

## Proje Hakkında

Hayvan barınakları, genellikle çok sayıda hayvanı barındırmakta ve sahiplendirme süreçlerini yönetmekte zorlanmaktadır. Bu proje, hayvanların barınağa kabulünden, sahiplendirme süreçlerine kadar her aşamayı dijital olarak yönetmeyi sağlar. Kullanıcılar, sisteme giriş yaparak hayvanları sahiplenebilir, başvuru süreçlerini takip edebilir ve yöneticiler bu başvuruları onaylayabilir.

### Proje Özellikleri

- **Hayvan Tanımlama**: Yeni bir hayvan barınağa geldiğinde, hayvanın tüm bilgileri (cins, yaş, sağlık durumu, vb.) sistemde kaydedilebilir.
- **Hayvan Sahiplendirme**: Kullanıcılar, sistem üzerinden hayvanları sahiplenmek için başvuru yapabilirler. Sahiplendirme süreci; başvuru yapma, bekleme ve onaylama adımlarını içerir.
- **Kullanıcı Yönetimi**: Sistemde iki tür kullanıcı bulunmaktadır:
  - **Admin**: Hayvan ekleyip düzenleyebilir, sahiplendirme başvurularını onaylayabilir.
  - **Kayıtlı Üye**: Hayvan sahiplenme başvurusu yapabilir ve kendi başvurularını takip edebilir.
- **Çok Dilli Destek**: Sistem en az iki farklı dilde kullanılabilir: Türkçe ve İngilizce.
- **API Hizmeti**: Sistemdeki hayvan bilgilerine ve sahiplendirme süreçlerine dışarıdan erişim sağlamak için bir API hizmeti sunulmaktadır.

## Kullanılan Teknolojiler

Bu proje aşağıdaki teknolojiler kullanılarak geliştirilmiştir:

- **ASP.NET Core 6/7 (MVC)**: Web uygulaması geliştirmek için kullanılan framework.
- **C#**: Uygulama geliştirme dili.
- **SQL Server / PostgreSQL**: Veritabanı yönetimi için kullanılan sistemler.
- **Entity Framework Core (ORM)**: Veritabanı işlemlerinin yönetimi için kullanılan ORM (Object Relational Mapping) aracı.
- **Bootstrap, HTML5, CSS3**: Kullanıcı arayüzü ve stil yönetimi için kullanılan teknolojiler.
- **JavaScript ve jQuery**: Dinamik içerik ve etkileşimler için kullanılan diller.


# Animal Shelter Web Project

This project was developed by **Mert Kan** as part of the **2023 Summer School Web Programming course at Sakarya University**. The project is a web application designed to streamline the **animal intake** and **adoption processes** for animal shelters.

## About the Project

Animal shelters often have to manage a large number of animals and face difficulties in handling the adoption processes. This project helps manage everything from animal intake to the adoption process digitally. Users can log in to the system, adopt animals, follow the application process, and administrators can approve or reject these applications.

### Project Features

- **Animal Registration**: When a new animal arrives at the shelter, all of its details (species, age, health status, etc.) can be recorded in the system.
- **Animal Adoption**: Users can apply to adopt animals through the system. The adoption process includes the steps of applying, waiting, and approval.
- **User Management**: There are two types of users in the system:
  - **Admin**: Can add and edit animals and approve adoption applications.
  - **Registered User**: Can submit adoption applications and track their own application status.
- **Multi-language Support**: The system supports at least two languages: Turkish and English.
- **API Service**: The system provides an API service to allow external access to animal data and adoption processes.

## Technologies Used

This project was developed using the following technologies:

- **ASP.NET Core 6/7 (MVC)**: Framework used for web application development.
- **C#**: Programming language used for the application.
- **SQL Server / PostgreSQL**: Database management systems used.
- **Entity Framework Core (ORM)**: ORM (Object Relational Mapping) tool used for managing database operations.
- **Bootstrap, HTML5, CSS3**: Technologies used for user interface and styling.
- **JavaScript and jQuery**: Used for dynamic content and interactivity.

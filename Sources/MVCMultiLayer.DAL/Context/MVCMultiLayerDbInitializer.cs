using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCMultiLayer.DAL.Context
{
#if DEBUG
    //public class MVCMultiLayerDbInitializer : System.Data.Entity.DropCreateDatabaseAlways<MVCMultiLayerDb>
    //public class MVCMultiLayerDbInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MVCMultiLayerDb>    
    public class MVCMultiLayerDbInitializer : System.Data.Entity.MigrateDatabaseToLatestVersion<MVCMultiLayerDb, Migrations.Configuration>
#else
    //public class MVCMultiLayerDbInitializer : System.Data.Entity.CreateDatabaseIfNotExists<MVCMultiLayerDb>
    public class MVCMultiLayerDbInitializer : System.Data.Entity.MigrateDatabaseToLatestVersion<MVCMultiLayerDb, Migrations.Configuration>
#endif
    {
        //protected override void Seed(ArtsDiscoverDb context)
        //{
        //    var enumToLookup = new EnumToLookup();
        //    enumToLookup.Apply(context);

        //    #region GALLERY CONFIGURATION
        //    context.GalleryConfigurations.Add(new Entities.GalleryConfiguration()
        //    {
        //        ID = 1,
        //        Name = "PRO FINE ARTS Limited",
        //        AddressLine1 = "Shop n.6, Upper G/F, Sunrise House",
        //        AddressLine2 = "27 Old Bailey Street",
        //        District = "Central",
        //        City = "Hong Kong",
        //        LogoPath = "~/_Images/Logo/ProFineArts.png",
        //        Culture = "zh-HK",
        //        DefaultCurrency = "HKD",
        //        EnableInvoiceDelete=true,
        //        EnableInvoiceEdit=true,
        //        MaxRowsInInvoice=4,
        //        MailServer = "smtp.sendgrid.net",
        //        MailServerPort = 587,
        //        MailServerUser = "azure_77d679e074316b7cf2dc7c212a83fa6d@azure.com",
        //        MailServerPassword = "kvo31ss5",
        //        MailSenderAddress = "info@parkviewarthk.com",
        //        UseSMTPS = false,
        //        IsDataAvailable = true,
        //        DateCreation = DateTime.Now,
        //        UserCreation = "System"
        //    });

        //    context.GalleryConfigurations.Add(new Entities.GalleryConfiguration()
        //    {
        //        ID = 2,
        //        Name = "Parkview Green Art 798",
        //        AddressLine1 = "Bababa bababa",
        //        AddressLine2 = "45, 798 Art place",                
        //        City = "Beijing",                
        //        Culture = "zh-HK",
        //        DefaultCurrency = "CNY",
        //        VAT = 12.5,
        //        EnableInvoiceDelete = false,
        //        EnableInvoiceEdit = false,
        //        MaxRowsInInvoice = 6,
        //        MailServer = "smtp.sendgrid.net",
        //        MailServerPort = 587,
        //        MailSenderAddress = "info@parkviewgreenart798.com",
        //        UseSMTPS = false,
        //        IsDataAvailable = true,
        //        DateCreation = DateTime.Now,
        //        UserCreation = "System"
        //    });
        //    #endregion

        //    #region ARTIST CATEGORIES
        //    context.ArtistCategories.Add(new Entities.ArtistCategory()
        //    {
        //        ID = 1,
        //        GalleryID = 1,
        //        CategoryDescription = "Asian Contemporary",
        //        DateCreation = DateTime.Now,
        //        UserCreation = "System"
        //    });

        //    context.ArtistCategories.Add(new Entities.ArtistCategory()
        //    {
        //        ID = 2,
        //        GalleryID = 1,
        //        CategoryDescription = "International Contemporary",
        //        DateCreation = DateTime.Now,
        //        UserCreation = "System"
        //    });

        //    context.ArtistCategories.Add(new Entities.ArtistCategory()
        //    {
        //        ID = 3,
        //        GalleryID = 1,
        //        CategoryDescription = "Modern",
        //        DateCreation = DateTime.Now,
        //        UserCreation = "System"
        //    });
        //    #endregion

        //    #region ARTISTS
        //    context.Artists.Add(new Entities.Artist()
        //    {
        //        ID = 1,
        //        Name = "Pippo Palmieri",
        //        APIEnabled = true,
        //        CategoryID = 1,
        //        GalleryID = 1,
        //        DateCreation = DateTime.Now,
        //        UserCreation = "System"
        //    });

        //    context.Artists.Add(new Entities.Artist()
        //    {
        //        ID = 2,
        //        Name = "Mario Fontana",
        //        APIEnabled = true,
        //        CategoryID = 2,
        //        GalleryID = 1,
        //        DateCreation = DateTime.Now,
        //        UserCreation = "System"
        //    });
        //    #endregion

        //    #region ARTWORK CATEGORIES
        //    context.ArtworkCategories.Add(new Entities.ArtworkCategory()
        //    {
        //        ID = 1,
        //        GalleryID = 1,
        //        CategoryDescription = "Paintings",
        //        DateCreation = DateTime.Now,
        //        UserCreation = "System"
        //    });

        //    context.ArtworkCategories.Add(new Entities.ArtworkCategory()
        //    {
        //        ID = 2,
        //        GalleryID = 1,
        //        CategoryDescription = "Sculpture",
        //        DateCreation = DateTime.Now,
        //        UserCreation = "System"
        //    });

        //    context.ArtworkCategories.Add(new Entities.ArtworkCategory()
        //    {
        //        ID = 3,
        //        GalleryID = 1,
        //        CategoryDescription = "Installation",
        //        DateCreation = DateTime.Now,
        //        UserCreation = "System"
        //    });

        //    context.ArtworkCategories.Add(new Entities.ArtworkCategory()
        //    {
        //        ID = 4,
        //        GalleryID = 1,
        //        CategoryDescription = "Photo",
        //        DateCreation = DateTime.Now,
        //        UserCreation = "System"
        //    });

        //    context.ArtworkCategories.Add(new Entities.ArtworkCategory()
        //    {
        //        ID = 5,
        //        GalleryID = 1,
        //        CategoryDescription = "Video",
        //        DateCreation = DateTime.Now,
        //        UserCreation = "System"
        //    });
        //    #endregion

        //    #region ARTWORKS
        //    Entities.Artwork artwork1 = new Entities.Artwork()
        //    {
        //        ID = 1,
        //        Title = "Che bella opera",
        //        Technique = "Acquarello su carta con tavole e salsicce",
        //        ArtistID = 1,
        //        Height = 10,
        //        Width = 48.5,
        //        Year = "2011",
        //        ArtworkCategoryID = 1,
        //        //hasBeenPurchased = true,
        //        APIEnabled = true,
        //        GalleryID = 1,
        //        DateCreation = DateTime.Now,
        //        UserCreation = "System"
        //    };
        //    context.Artworks.Add(artwork1);

        //    context.Artworks.Add(new Entities.Artwork()
        //    {
        //        ID = 2,
        //        Title = "Gino sugli scogli",
        //        Technique = "Olio su tela",
        //        ArtistID = 1,
        //        Height = 344,
        //        Width = 418.5,
        //        Year = "imprecisato",
        //        ArtworkCategoryID = 1,
        //        GalleryID = 1,
        //        DateCreation = DateTime.Now,
        //        UserCreation = "System"
        //    });

        //    context.Artworks.Add(new Entities.Artwork()
        //    {
        //        ID = 3,
        //        Title = "Man into woman",
        //        Technique = "Acquarello su carta con tavole e salsicce",
        //        ArtistID = 2,
        //        Height = 10,
        //        Width = 48.5,
        //        Year = "2012",
        //        ArtworkCategoryID = 2,
        //        APIEnabled = true,
        //        GalleryID = 1,
        //        DateCreation = DateTime.Now,
        //        UserCreation = "System"
        //    });

        //    context.Artworks.Add(new Entities.Artwork()
        //    {
        //        ID = 4,
        //        Title = "Gino sulla scogliera",
        //        Technique = "Pino su antracite",
        //        ArtistID = 1,
        //        Height = 344,
        //        Width = 418.5,
        //        Year = "prima metà del 700",
        //        ArtworkCategoryID = 3,
        //        APIEnabled = true,
        //        GalleryID = 1,
        //        DateCreation = DateTime.Now,
        //        UserCreation = "System"
        //    });

        //    context.Artworks.Add(new Entities.Artwork()
        //    {
        //        ID = 5,
        //        Title = "Opera ritornata",
        //        Technique = "Mista",
        //        ArtistID = 1,
        //        Height = 344,
        //        Width = 418.5,
        //        Year = "prima metà del 700",
        //        ArtworkCategoryID = 1,
        //        APIEnabled = true,
        //        GalleryID = 1,
        //        DateCreation = DateTime.Now,
        //        UserCreation = "System"
        //    });

        //    context.Artworks.Add(new Entities.Artwork()
        //    {
        //        ID = 6,
        //        Title = "Tagli e buchi",
        //        Technique = "Mista",
        //        ArtistID = 2,
        //        Height = 97,
        //        Width = 114,
        //        APIEnabled = true,
        //        ArtworkCategoryID = 1,
        //        GalleryID = 2,
        //        DateCreation = DateTime.Now,
        //        UserCreation = "System"
        //    });
        //    #endregion

        //    #region ARTWORKDATAINS
        //    context.ArtworkDataIns.Add(new Entities.ArtworkDataIn()
        //    {
        //        ID = 5,
        //        ArtworkID = 5,
        //        IsReturned = true,
        //        GalleryID = 1,
        //        DateCreation = DateTime.Now,
        //        UserCreation = "System"
        //    });
        //    #endregion

        //    #region CONSIGNMENT TYPES
        //    context.ConsignmentTypes.Add(new Entities.ConsignmentType()
        //    {
        //        ID = 1,
        //        Code = "BEIJ",
        //        ConsignmentTypeDescription = "Consignment from Beijing",
        //        GalleryID = 1,
        //        DateCreation = DateTime.Now,
        //        UserCreation = "System"
        //    });

        //    context.ConsignmentTypes.Add(new Entities.ConsignmentType()
        //    {
        //        ID = 2,
        //        Code = "HKPV",
        //        ConsignmentTypeDescription = "Consignment from HK Parkview",
        //        GalleryID = 1,
        //        DateCreation = DateTime.Now,
        //        UserCreation = "System"
        //    });

        //    context.ConsignmentTypes.Add(new Entities.ConsignmentType()
        //    {
        //        ID = 3,
        //        Code = "ART",
        //        ConsignmentTypeDescription = "Consignment from Artists",
        //        GalleryID = 1,
        //        DateCreation = DateTime.Now,
        //        UserCreation = "System"
        //    });

        //    context.ConsignmentTypes.Add(new Entities.ConsignmentType()
        //    {
        //        ID = 4,
        //        Code = "PRGA",
        //        ConsignmentTypeDescription = "Consignment from Privates or Galleries",
        //        GalleryID = 1,
        //        DateCreation = DateTime.Now,
        //        UserCreation = "System"
        //    });
        //    #endregion

        //    #region CUSTOMER CATEGORIES
        //    context.CustomerCategories.Add(new Entities.CustomerCategory()
        //    {
        //        ID = 1,
        //        Code = "C",
        //        CustomerCategoryDescription = "Collector",
        //        GalleryID = 1,
        //        DateCreation = DateTime.Now,
        //        UserCreation = "System"
        //    });

        //    context.CustomerCategories.Add(new Entities.CustomerCategory()
        //    {
        //        ID = 2,
        //        Code = "G",
        //        CustomerCategoryDescription = "Gallery",
        //        GalleryID = 1,
        //        DateCreation = DateTime.Now,
        //        UserCreation = "System"
        //    });

        //    context.CustomerCategories.Add(new Entities.CustomerCategory()
        //    {
        //        ID = 3,
        //        Code = "D",
        //        CustomerCategoryDescription = "Dealer",
        //        GalleryID = 1,
        //        DateCreation = DateTime.Now,
        //        UserCreation = "System"
        //    });

        //    context.CustomerCategories.Add(new Entities.CustomerCategory()
        //    {
        //        ID = 4,
        //        Code = "M",
        //        CustomerCategoryDescription = "Media",
        //        GalleryID = 1,
        //        DateCreation = DateTime.Now,
        //        UserCreation = "System"
        //    });

        //    context.CustomerCategories.Add(new Entities.CustomerCategory()
        //    {
        //        ID = 5,
        //        Code = "F",
        //        CustomerCategoryDescription = "Friend",
        //        GalleryID = 1,
        //        DateCreation = DateTime.Now,
        //        UserCreation = "System"
        //    });

        //    context.CustomerCategories.Add(new Entities.CustomerCategory()
        //    {
        //        ID = 6,
        //        Code = "A",
        //        CustomerCategoryDescription = "Artist",
        //        GalleryID = 1,
        //        DateCreation = DateTime.Now,
        //        UserCreation = "System"
        //    });

        //    context.CustomerCategories.Add(new Entities.CustomerCategory()
        //    {
        //        ID = 7,
        //        Code = "PV",
        //        CustomerCategoryDescription = "Parkview",
        //        GalleryID = 1,
        //        DateCreation = DateTime.Now,
        //        UserCreation = "System"
        //    });
        //    #endregion

        //    #region CUSTOMERS
        //    context.Customers.Add(new Entities.Customer()
        //    {
        //        ID = 1,
        //        Name = "Zu Gijyung",
        //        Surname = "Wangtsu",
        //        Address1 = "Rue de la Victorie 334/f",
        //        Address2 = "Pont Magnific",
        //        City = "Paris",
        //        District = "4F",
        //        Phone1 = "00425866958",
        //        Phone2 = "335 6254865",
        //        Email = "davide@dbtek.com.hk",
        //        Notes = "The better customer we have. Sell him everithing!!!",
        //        IsVIP = true,
        //        GalleryID = 1,
        //        DateCreation = DateTime.Now,
        //        UserCreation = "System"

        //    });

        //    context.Customers.Add(new Entities.Customer()
        //    {
        //        ID = 2,
        //        Name = "Mariello",
        //        Surname = "Prapapappo",
        //        Title = "ArtIst, CEO",
        //        Address1 = "via Magnifica 4",
        //        City = "Milano",
        //        Phone1 = "+39025455689",
        //        Phone2 = "335 7855498",
        //        Email = "davide.benvegnu@outlook.com",
        //        IsDealer = true,
        //        GalleryID = 1,
        //        DateCreation = DateTime.Now,
        //        UserCreation = "System"
        //    });

        //    context.Customers.Add(new Entities.Customer()
        //    {
        //        ID = 3,
        //        Name = "Steve",
        //        Surname = "Aoki",
        //        Address1 = "23, Agonant street",
        //        City = "Hong Kong",
        //        District = "Kowloon",
        //        Phone1 = "0005856215",
        //        GalleryID = 1,
        //        DateCreation = DateTime.Now,
        //        UserCreation = "System",
        //        Artworks = new List<Entities.Artwork>() { artwork1 }
        //    });
        //    #endregion

        //    context.SaveChanges();

        //    base.Seed(context);


        //}
    }
}

﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace Superjack.MultiSites.Api.DataAccess
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<Block> Blocks { get; set; }
    public DbSet<BlockField> BlockFields { get; set; }
    public DbSet<Page> Pages { get; set; }
    public DbSet<PageBlock> PageBlocks { get; set; }
    public DbSet<PageField> PageFields { get; set; }
    public DbSet<PageType> PageTypes { get; set; }
    public DbSet<Site> Sites { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      
      var pageTypes = new PageType[]
      {
        new PageType(){Id="Root", Body=@"{""useBlocks"": true, ""title"": ""Homepage""}", DateCreated=DateTime.Now },
        new PageType(){Id="StandardPage", Body=@"{""useBlocks"": true, ""title"": ""Standard Page""}", DateCreated=DateTime.Now },
        new PageType(){Id="ProductList", Body=@"{""useBlocks"": true, ""title"": ""Product List""}", DateCreated=DateTime.Now },
        new PageType(){Id="ProductDetail", Body=@"{""useBlocks"": true, ""title"": ""ProductDetail""}", DateCreated=DateTime.Now },
        new PageType(){Id="EventList", Body=@"{""useBlocks"": true, ""title"": ""Event List""}", DateCreated=DateTime.Now },
        new PageType(){Id="EventDetail", Body=@"{""useBlocks"": true, ""title"": ""Event Detail""}", DateCreated=DateTime.Now },
        new PageType(){Id="ArticleList", Body=@"{""useBlocks"": true, ""title"": ""Article List""}", DateCreated=DateTime.Now },
        new PageType(){Id="ArticleDetail", Body=@"{""useBlocks"": true, ""title"": ""Article Detail""}", DateCreated=DateTime.Now },
        new PageType(){Id="FeatureLanding", Body=@"{""useBlocks"": true, ""title"": ""Feature Landing""}", DateCreated=DateTime.Now },
        new PageType(){Id="Error", Body=@"{""useBlocks"": true, ""title"": ""Error""}", DateCreated=DateTime.Now },
        new PageType(){Id="Search", Body=@"{""useBlocks"": true, ""title"": ""Search""}", DateCreated=DateTime.Now },
        new PageType(){Id="SearchResults", Body=@"{""useBlocks"": true, ""title"": ""Search Results""}", DateCreated=DateTime.Now },
        new PageType(){Id="Member", Body=@"{""useBlocks"": true, ""title"": ""Member""}", DateCreated=DateTime.Now },
        new PageType(){Id="Transaction", Body=@"{""useBlocks"": true, ""title"": ""Transaction""}", DateCreated=DateTime.Now }

      };

      modelBuilder.Entity<PageType>().HasData(pageTypes);


      var blocks = new Block[]
      {
        new Block(){Id=1,DateCreated=DateTime.Now, DateModified=DateTime.Now, BlockType="columnContainer", Title="Columns", CanHaveChildren=true},
        new Block(){Id=2,DateCreated=DateTime.Now, DateModified=DateTime.Now, BlockType="button", Title="Button", CanHaveChildren=false},
        new Block(){Id=3,DateCreated=DateTime.Now, DateModified=DateTime.Now, BlockType="checkbox", Title="Checkbox", CanHaveChildren=false},
        new Block(){Id=4,DateCreated=DateTime.Now, DateModified=DateTime.Now, BlockType="checklist", Title="Checklist", CanHaveChildren=false},
        new Block(){Id=5,DateCreated=DateTime.Now, DateModified=DateTime.Now, BlockType="dataListGroup", Title="Data List Group", CanHaveChildren=false},
        new Block(){Id=6,DateCreated=DateTime.Now, DateModified=DateTime.Now, BlockType="datePicker", Title="Date Picker", CanHaveChildren=false},
        new Block(){Id=7,DateCreated=DateTime.Now, DateModified=DateTime.Now, BlockType="divider", Title="Divider", CanHaveChildren=false},
        new Block(){Id=8,DateCreated=DateTime.Now, DateModified=DateTime.Now, BlockType="dropDown", Title="Drop-down", CanHaveChildren=false},
        new Block(){Id=9,DateCreated=DateTime.Now, DateModified=DateTime.Now, BlockType="editableTable", Title="Editable Table", CanHaveChildren=false},
        new Block(){Id=10,DateCreated=DateTime.Now, DateModified=DateTime.Now, BlockType="fileUpload", Title="File Upload", CanHaveChildren=false},
        new Block(){Id=11,DateCreated=DateTime.Now, DateModified=DateTime.Now, BlockType="heading", Title="heading", CanHaveChildren=false},
        new Block(){Id=12,DateCreated=DateTime.Now, DateModified=DateTime.Now, BlockType="subHeading", Title="Sub-heading", CanHaveChildren=false},
        new Block(){Id=13,DateCreated=DateTime.Now, DateModified=DateTime.Now, BlockType="listGroup", Title="List Group", CanHaveChildren=false},
        new Block(){Id=14,DateCreated=DateTime.Now, DateModified=DateTime.Now, BlockType="multiLineTextbox", Title="Multi-line Textbox", CanHaveChildren=false},
        new Block(){Id=15,DateCreated=DateTime.Now, DateModified=DateTime.Now, BlockType="radioGroup", Title="Radio Group", CanHaveChildren=false},
        new Block(){Id=16,DateCreated=DateTime.Now, DateModified=DateTime.Now, BlockType="signature", Title="Signature", CanHaveChildren=false},
        new Block(){Id=17,DateCreated=DateTime.Now, DateModified=DateTime.Now, BlockType="table", Title="Table", CanHaveChildren=false},
        new Block(){Id=18,DateCreated=DateTime.Now, DateModified=DateTime.Now, BlockType="textBlock", Title="Text Block", CanHaveChildren=false},
        new Block(){Id=19,DateCreated=DateTime.Now, DateModified=DateTime.Now, BlockType="textBox", Title="TextBox", CanHaveChildren=false},
        new Block(){Id=20,DateCreated=DateTime.Now, DateModified=DateTime.Now, BlockType="timePicker", Title="Time Picker", CanHaveChildren=false},
        new Block(){Id=21,DateCreated=DateTime.Now, DateModified=DateTime.Now, BlockType="toggleSwitch", Title="Toggle Switch", CanHaveChildren=false},
        new Block(){Id=22,DateCreated=DateTime.Now, DateModified=DateTime.Now, BlockType="imageGallery", Title="Image Gallery", CanHaveChildren=true},
        new Block(){Id=23,DateCreated=DateTime.Now, DateModified=DateTime.Now, BlockType="image", Title="Image", CanHaveChildren=false},
        new Block(){Id=24,DateCreated=DateTime.Now, DateModified=DateTime.Now, BlockType="imageLink", Title="Image Link", CanHaveChildren=false},
        new Block(){Id=25,DateCreated=DateTime.Now, DateModified=DateTime.Now, BlockType="productGallery", Title="Product Listing", CanHaveChildren=true},
        new Block(){Id=26,DateCreated=DateTime.Now, DateModified=DateTime.Now, BlockType="product", Title="Product", CanHaveChildren=false},
        new Block(){Id=27,DateCreated=DateTime.Now, DateModified=DateTime.Now, BlockType="carousel", Title="Carousel", CanHaveChildren=true},
        new Block(){Id=28,DateCreated=DateTime.Now, DateModified=DateTime.Now, BlockType="carouselItem", Title="Carousel Item", CanHaveChildren=true},
        new Block(){Id=29,DateCreated=DateTime.Now, DateModified=DateTime.Now, BlockType="login", Title="Login", CanHaveChildren=false},
        new Block(){Id=30,DateCreated=DateTime.Now, DateModified=DateTime.Now, BlockType="registration", Title="Registration", CanHaveChildren=false},
        new Block(){Id=31,DateCreated=DateTime.Now, DateModified=DateTime.Now, BlockType="shoppingBasket", Title="Shopping Basket", CanHaveChildren=false},
        new Block(){Id=32,DateCreated=DateTime.Now, DateModified=DateTime.Now, BlockType="checkout", Title="Checkout", CanHaveChildren=false},
        new Block(){Id=33,DateCreated=DateTime.Now, DateModified=DateTime.Now, BlockType="search", Title="Search", CanHaveChildren=false},
        new Block(){Id=34,DateCreated=DateTime.Now, DateModified=DateTime.Now, BlockType="searchItem", Title="Search Item", CanHaveChildren=false},
        new Block(){Id=35,DateCreated=DateTime.Now, DateModified=DateTime.Now, BlockType="card", Title="Card", CanHaveChildren=true}


      };

      modelBuilder.Entity<Block>().HasData(blocks);

      var blockFields = new BlockField[]
      {
        new BlockField(){Id=1, BlockId=1, Title="Number of Columns", DataType="int", SortOrder=0, Value="1"}
      };

      modelBuilder.Entity<BlockField>().HasData(blockFields);

      var sites = new Site[]
      {
        new Site(){Id=1, Protocol="https", DomainName="superjack.co.uk", Culture="en-GB"}
      };

      modelBuilder.Entity<Site>().HasData(sites);

      byte[] passwordHash, passwordSalt;
      CreatePasswordHash("Superjack1", out passwordHash, out passwordSalt);

      var users = new User[]
      {
        new User(){Id=1, FirstName="Stef", Surname="Cunning", Status="Active", Username="services@superjack.co.uk", DateCreated=DateTime.Now, PasswordHash=passwordHash, PasswordSalt=passwordSalt}
      };

      modelBuilder.Entity<User>().HasData(users);

      var pageIdentifiers = new string[]
      {
        Guid.NewGuid().ToString().ToLower(),
        Guid.NewGuid().ToString().ToLower(),
        Guid.NewGuid().ToString().ToLower(),
        Guid.NewGuid().ToString().ToLower(),
        Guid.NewGuid().ToString().ToLower()

      };

      var pages = new Page[]
      {
        new Page(){Id=1, PageIdentifier=pageIdentifiers[0], DateCreated=DateTime.Now, DateModified=DateTime.Now, DateScheduledPublish=DateTime.Now.Subtract(new TimeSpan(4,0,0,0,0)), DateScheduledExpiry=null, PageTypeId="Root", NavigationTitle="Home", Title="Home", ParentPageIdentifier=null, Level=0, Route="/", SiteId=1, SortOrder=0, Draft=false, Published=true, Disabled=false, Binned=false},
        new Page(){Id=2, PageIdentifier=pageIdentifiers[1], DateCreated=DateTime.Now, DateModified=DateTime.Now, DateScheduledPublish=DateTime.Now, PageTypeId="StandardPage", DateScheduledExpiry=null, NavigationTitle="Portfolio", Title="Portfolio", ParentPageIdentifier=pageIdentifiers[0], Level=1, Route="/portfolio", SiteId=1, SortOrder=1, Draft=false, Published=true, Disabled=false, Binned=false},
        new Page(){Id=3, PageIdentifier=pageIdentifiers[2], DateCreated=DateTime.Now, DateModified=DateTime.Now, DateScheduledPublish=DateTime.Now, PageTypeId="StandardPage", DateScheduledExpiry=null, NavigationTitle="Regulatory Services", Title="Regulatory Services", ParentPageIdentifier=pageIdentifiers[1], Level=2, Route="/portfolio/regulatory-services", SiteId=1, SortOrder=0, Draft=false, Published=true, Disabled=false, Binned=false},
        new Page(){Id=4, PageIdentifier=pageIdentifiers[3], DateCreated=DateTime.Now, DateModified=DateTime.Now, DateScheduledPublish=DateTime.Now, PageTypeId="StandardPage", DateScheduledExpiry=null, NavigationTitle="About", Title="About", ParentPageIdentifier=pageIdentifiers[0], Level=1, Route="/about", SiteId=1, SortOrder=0, Draft=false, Published=true, Disabled=false, Binned=false},
        new Page(){Id=5, PageIdentifier=pageIdentifiers[4], DateCreated=DateTime.Now, DateModified=DateTime.Now, DateScheduledPublish=DateTime.Now, PageTypeId="StandardPage", DateScheduledExpiry=null, NavigationTitle="Contact", Title="Contact", ParentPageIdentifier=pageIdentifiers[0], Level=1, Route="/contact", SiteId=1, SortOrder=2, Draft=false, Published=true, Disabled=false, Binned=false},
        new Page(){Id=6, PageIdentifier=pageIdentifiers[0], DateCreated=DateTime.Now, DateModified=DateTime.Now, DateScheduledPublish=DateTime.Now.Subtract(new TimeSpan(3,0,0,0,0)), DateScheduledExpiry=null, PageTypeId="Root", NavigationTitle="Home", Title="Home", ParentPageIdentifier=null, Level=0, Route="/", SiteId=1, SortOrder=0, Draft=false, Published=true, Disabled=false, Binned=false},
        new Page(){Id=7, PageIdentifier=pageIdentifiers[0], DateCreated=DateTime.Now, DateModified=DateTime.Now, DateScheduledPublish=DateTime.Now.Subtract(new TimeSpan(2,0,0,0,0)), DateScheduledExpiry=DateTime.Now.Subtract(new TimeSpan(1,0,0,0,0)), PageTypeId="Root", NavigationTitle="Home", Title="Home", ParentPageIdentifier=null, Level=0, Route="/", SiteId=1, SortOrder=0, Draft=false, Published=true, Disabled=false, Binned=false},
        new Page(){Id=8, PageIdentifier=pageIdentifiers[0], DateCreated=DateTime.Now, DateModified=DateTime.Now, DateScheduledPublish=null, PageTypeId="Root", NavigationTitle="Home", DateScheduledExpiry=null, Title="Home", ParentPageIdentifier=null, Level=0, Route="/", SiteId=1, SortOrder=0, Draft=true, Published=false, Disabled=false, Binned=false}

      };

      modelBuilder.Entity<Page>().HasData(pages);

      var pageBlocks = new PageBlock[]
      {
        new PageBlock(){Id=1, PageId=1, BlockId=1, SortOrder=0}
      };

      modelBuilder.Entity<PageBlock>().HasData(pageBlocks);

      var pageFields = new PageField[]
      {
        new PageField(){Id=1, PageBlockId=1, FieldId=1, Title="Number of Columns", DataType="int", SortOrder=0, Value="3"}
      };

      modelBuilder.Entity<PageField>().HasData(pageFields);

      base.OnModelCreating(modelBuilder);
    }

    private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {

      if (password == null) throw new ArgumentNullException("password");
      if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

      using (var hmac = new HMACSHA512())
      {
        passwordSalt = hmac.Key;
        passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
      }
    }


    private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
    {
      if (password == null) throw new ArgumentNullException("password");
      if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
      if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
      if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");



      using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
      {
        var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        for (int i = 0; i < computedHash.Length; i++)
        {
          if (computedHash[i] != storedHash[i]) return false;
        }
      }

      return true;
    }


  }
}
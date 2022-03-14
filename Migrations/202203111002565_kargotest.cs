namespace MVC5TicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kargotest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KargoDetays",
                c => new
                    {
                        KargoDetayID = c.Int(nullable: false, identity: true),
                        KargoDetayAciklama = c.String(maxLength: 300, unicode: false),
                        KargoDetayTakipKodu = c.String(maxLength: 10, unicode: false),
                        KargoDetayPersonel = c.String(maxLength: 30, unicode: false),
                        KargoDetayAlici = c.String(maxLength: 30, unicode: false),
                        KargoTarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.KargoDetayID);
            
            CreateTable(
                "dbo.KargoTakips",
                c => new
                    {
                        KargaTakipID = c.Int(nullable: false, identity: true),
                        KargoTakipKodu = c.String(maxLength: 10, unicode: false),
                        KargoTakipAciklama = c.String(maxLength: 100, unicode: false),
                        KargoTakipTarih = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.KargaTakipID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.KargoTakips");
            DropTable("dbo.KargoDetays");
        }
    }
}

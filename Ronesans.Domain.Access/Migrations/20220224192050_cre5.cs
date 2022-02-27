using Microsoft.EntityFrameworkCore.Migrations;

namespace Ronesans.Domain.Access.Migrations
{
    public partial class cre5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            #region cities insert
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('01', N'Adana')            ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('02', N'Adıyaman')         ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('03', N'Afyon')            ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('04', N'Ağrı')             ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('05', N'Amasya')           ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('06', N'Ankara')           ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('07', N'Antalya')          ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('08', N'Artvin')           ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('09', N'Aydın')            ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('10', N'Balıkesir')        ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('11', N'Bilecik')          ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('12', N'Bingöl')           ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('13', N'Bitlis')           ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('14', N'Bolu')             ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('15', N'Burdur')           ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('16', N'Bursa')            ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('17', N'Çanakkale')        ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('18', N'Çankırı')          ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('19', N'Çorum')            ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('20', N'Denizli')          ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('21', N'Diyarbakır')       ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('22', N'Edirne')           ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('23', N'Elazığ')           ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('24', N'Erzincan')         ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('25', N'Erzurum')          ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('26', N'Eskişehir')        ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('27', N'Gaziantep')        ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('28', N'Giresun')          ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('29', N'Gümüşhane')        ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('30', N'Hakkari')          ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('31', N'Hatay')            ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('32', N'Isparta')          ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('33', N'Mersin')           ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('34', N'İstanbul')         ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('35', N'İzmir')            ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('36', N'Kars')             ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('37', N'Kastamonu')        ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('38', N'Kayseri')          ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('39', N'Kırklareli')       ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('40', N'Kırşehir')         ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('41', N'Kocaeli')          ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('42', N'Konya')            ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('43', N'Kütahya')          ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('44', N'Malatya')          ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('45', N'Manisa')           ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('46', N'K.Maraş')          ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('47', N'Mardin')           ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('48', N'Muğla')            ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('49', N'Muş')              ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('50', N'Nevşehir')         ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('51', N'Niğde')            ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('52', N'Ordu')             ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('53', N'Rize')             ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('54', N'Sakarya')          ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('55', N'Samsun')           ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('56', N'Siirt')            ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('57', N'Sinop')            ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('58', N'Sivas')            ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('59', N'Tekirdağ')         ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('60', N'Tokat')            ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('61', N'Trabzon')          ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('62', N'Tunceli')          ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('63', N'Şanlıurfa')        ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('64', N'Uşak')             ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('65', N'Van')              ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('66', N'Yozgat')           ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('67', N'Zonguldak')        ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('68', N'Aksaray')          ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('69', N'Bayburt')          ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('70', N'Karaman')          ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('71', N'Kırıkkale')        ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('72', N'Batman')           ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('73', N'Şırnak')           ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('74', N'Bartın')           ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('75', N'Ardahan')          ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('76', N'Iğdır')            ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('77', N'Yalova')           ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('78', N'Karabük')          ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('79', N'Kilis')            ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('80', N'Osmaniye')         ");
            migrationBuilder.Sql("INSERT INTO Cities VALUES ('81', N'Düzce')            ");
            #endregion
            #region genders insert
            migrationBuilder.Sql("INSERT INTO Genders VALUES('01', 'Erkek')");
            migrationBuilder.Sql("INSERT INTO Genders VALUES('02', 'Kadın')");
            #endregion
            #region roles insert
            migrationBuilder.Sql("INSERT INTO Roles VALUES ('01', 'Admin','admin')");
            migrationBuilder.Sql("INSERT INTO Roles VALUES ('02', 'User','user')");
            #endregion
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

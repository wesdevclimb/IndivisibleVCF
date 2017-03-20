using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace IndivisibleVCF.Models
{

    public class ReprensentativeContactInfo
    {
        [JsonProperty(propertyName:"bioguide_id")]
        public string BioguideId { get; set; }
        [JsonProperty(propertyName: "birthday")]
        public string Birthday { get; set; }
        [JsonProperty(propertyName: "chamber")]
        public string Chamber { get; set; }
        [JsonProperty(propertyName: "contact_form")]
        public string ContactForm { get; set; }
        [JsonProperty(propertyName: "crp_id")]
        public string CrpId { get; set; }
        [JsonProperty(propertyName: "district")]
        public int? District { get; set; }
        [JsonProperty(propertyName: "facebook_id")]
        public string FacebookId { get; set; }
        [JsonProperty(propertyName: "fax")]
        public string Fax { get; set; }
        [JsonProperty(propertyName: "fec_ids")]
        public string[] FecIds { get; set; }
        [JsonProperty(propertyName: "first_name")]
        public string FirstName { get; set; }
        [JsonProperty(propertyName: "gender")]
        public string Gender { get; set; }
        [JsonProperty(propertyName: "govtrack_id")]
        public string GovtrackId { get; set; }
        [JsonProperty(propertyName: "icpsr_id")]
        public int? IcpsrId { get; set; }
        [JsonProperty(propertyName: "in_office")]
        public bool? InOffice { get; set; }
        [JsonProperty(propertyName: "last_name")]
        public string LastName { get; set; }
        [JsonProperty(propertyName: "leadership_role")]
        public string LeadershipRole { get; set; }
        [JsonProperty(propertyName: "middle_name")]
        public string MiddleName { get; set; }
        [JsonProperty(propertyName: "name_suffix")]
        public string NameSuffix { get; set; }
        [JsonProperty(propertyName: "nickname")]
        public string Nickname { get; set; }
        [JsonProperty(propertyName: "oc_email")]
        public string OcEmail { get; set; }
        [JsonProperty(propertyName: "ocd_id")]
        public string OcdId { get; set; }
        [JsonProperty(propertyName: "office")]
        public string Office { get; set; }
        [JsonProperty(propertyName: "party")]
        public string Party { get; set; }
        [JsonProperty(propertyName: "phone")]
        public string Phone { get; set; }
        [JsonProperty(propertyName: "state")]
        public string State { get; set; }
        [JsonProperty(propertyName: "state_name")]
        public string StateName { get; set; }
        [JsonProperty(propertyName: "term_end")]
        public string TermEnd { get; set; }
        [JsonProperty(propertyName: "term_start")]
        public string TermStart { get; set; }
        [JsonProperty(propertyName: "thomas_id")]
        public string ThomasId { get; set; }
        [JsonProperty(propertyName: "title")]
        public string Title { get; set; }
        [JsonProperty(propertyName: "twitter_id")]
        public string TwitterId { get; set; }
        [JsonProperty(propertyName: "votesmart_id")]
        public int? VotesmartId { get; set; }
        [JsonProperty(propertyName: "website")]
        public string Website { get; set; }
        [JsonProperty(propertyName: "youtube_id")]
        public string YoutubeId { get; set; }

        public string BuildVCard()
        {
            var strvCardBuilder = new StringBuilder();
            strvCardBuilder.AppendLine("BEGIN:VCARD");
            strvCardBuilder.AppendLine("VERSION:3.0");
            strvCardBuilder.AppendLine("N:Gump;Forrest;;Mr.;");
            strvCardBuilder.AppendLine("FN:Forrest Gump");
            strvCardBuilder.AppendLine("ORG:Bubba Gump Shrimp Co.");
            strvCardBuilder.AppendLine("TITLE:Shrimp Man");
            strvCardBuilder.AppendLine("PHOTO;VALUE=URI;TYPE=GIF:http://www.example.com/dir_photos/my_photo.gif");
            strvCardBuilder.AppendLine("TEL;TYPE=WORK,VOICE:(111) 555-1212");
            strvCardBuilder.AppendLine("TEL;TYPE=HOME,VOICE:(404) 555-1212");
            strvCardBuilder.AppendLine("ADR;TYPE=WORK,PREF:;;100 Waters Edge;Baytown;LA;30314;United States of America");
            strvCardBuilder.AppendLine("LABEL;TYPE=WORK,PREF:100 Waters Edge\nBaytown\, LA 30314\nUnited States of America");
            strvCardBuilder.AppendLine("ADR;TYPE=HOME:;;42 Plantation St.;Baytown;LA;30314;United States of America");
            strvCardBuilder.AppendLine("LABEL;TYPE=HOME:42 Plantation St.\nBaytown\, LA 30314\nUnited States of America");
            strvCardBuilder.AppendLine("EMAIL:forrestgump@example.com");
            strvCardBuilder.AppendLine("REV:" + DateTime.Now);
            strvCardBuilder.AppendLine("END:VCARD");

            //var strvCardBuilder = new StringBuilder();
            //strvCardBuilder.AppendLine("BEGIN:VCARD");
            //strvCardBuilder.AppendLine("VERSION:2.1");
            //strvCardBuilder.AppendLine("N:" + LastName + ";" + FirstName);
            //strvCardBuilder.AppendLine("FN:" + FirstName + " " + LastName);
            //strvCardBuilder.Append("ADR;HOME;PREF:;;");
            //strvCardBuilder.Append(Address + ";");
            //strvCardBuilder.Append(City + ";;");
            //strvCardBuilder.AppendLine(Country);
            //strvCardBuilder.AppendLine("ORG:" + Company);
            //strvCardBuilder.AppendLine("TITLE:" + Title);
            //strvCardBuilder.AppendLine("TEL;WORK;VOICE:" + Phone);
            //strvCardBuilder.AppendLine("EMAIL;PREF;INTERNET:" + OcEmail);
            //strvCardBuilder.AppendLine("PHOTO;ENCODING=BASE64;TYPE=JPEG:");
            //strvCardBuilder.AppendLine(Convert.ToBase64String(Image));
            //strvCardBuilder.AppendLine(string.Empty);
            //strvCardBuilder.AppendLine(string.Empty);
            //strvCardBuilder.AppendLine(string.Empty);
            //strvCardBuilder.AppendLine("END:VCARD");
            //return strvCardBuilder.ToString();
        }
    }


    public class RepresentativeSearchResult
    {
        [JsonProperty(propertyName: "results")]
        public ReprensentativeContactInfo[] Results { get; set; }
        [JsonProperty(propertyName: "count")]
        public int? Count { get; set; }
        [JsonProperty(propertyName: "page")]
        public Page Page { get; set; }
    }


    public class Page
    {
        [JsonProperty(propertyName: "count")]
        public int? Count { get; set; }
        [JsonProperty(propertyName: "per_page")]
        public int? PerPage { get; set; }
        [JsonProperty(propertyName: "page")]
        public int? CurrentPage { get; set; }
    }
}
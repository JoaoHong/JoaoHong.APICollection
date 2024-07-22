using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace JoaoHong.APICollection.Domain.Entities
{
	[Table("ApiCollectionUsers")]
	public class Users
	{
		[Column("UserId")]
		[JsonIgnore]
		[Key]
		public long UserId { get; set; }
		[Column("Name")]
		public string Nome { get; set; }
		[Column("Password")]
		public string Senha { get; set; }
		[Column("CreatedAt")]
		[NotMapped]
		[JsonIgnore]
		public DateTime? CreatedAt { get; set; }
		[Column("Description")]
		public string? Description { get; set; }
		[Column("Email")]
		public string Email {  get; set; }
	}
}

using Serilog;
using Dapper;
using MySql.Data.MySqlClient;
using ABC.Shared.Models;
using System.Net.Sockets;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ABC.Shared.Services;

public partial class ApplicationUserService_SQL
{

	#region ApplicationUsers CRUD
	//* GETS ALL ApplicationUsers
	public async Task<List<ApplicationUser>> GetApplicationUserListData(DbContext context)
	{
		List<ApplicationUser> _applicationUser = new List<ApplicationUser>();
		try
		{
			var applicationUserList = await context.Set<ApplicationUser>().ToListAsync();
			var userRoles = await context.Set<IdentityUserRole<string>>().ToListAsync();
			var roles = await context.Set<IdentityRole>().ToListAsync();

			foreach (var item in applicationUserList)
			{
				var userRoleIds = userRoles.FirstOrDefault(x => x.UserId == item.Id);
				if (userRoleIds != null)
				{
					var userRole = roles.FirstOrDefault(x => x.Id == userRoleIds.RoleId);
					if (userRole != null)
					{
						item.Role = userRole.Name;
					}
				}
				_applicationUser.Add(item);
			}
			return _applicationUser;
		}
		catch (Exception ex)
		{
			Log.Error(ex.ToString());
			return _applicationUser;
		}
	}



	//private async Task<List<ApplicationUser>> GetApplicationUserListData(dynamic DBContext)
	//{
	//	List<ApplicationUser> _applicationUser = [];
	//	try
	//	{
	//		var context = DBContext;
	//		var applicationUserList = context.ApplicationUsers;
	//		foreach (var item in applicationUserList)
	//		{
	//			_applicationUser.Add(item);
	//		}
	//		return _applicationUser;
	//	}
	//	catch (Exception ex)
	//	{
	//		Log.Error(ex.ToString());
	//		return _applicationUser;
	//	}
	//}



	//* GETS SINGLE ApplicationUsers BASE ON ID 
	private async Task<ApplicationUser> GetApplicationUserData(dynamic DBContext, string id)
	{
		ApplicationUser _applicationUser = new();
		try
		{
			var context = DBContext;
			ApplicationUser result = context.ApplicationUsers.Find(id);
			ApplicationUser userFilteredInfo = new()
			{
				FirstName = result.FirstName,
				LastName = result.LastName,
				PhoneNumber = result.PhoneNumber,
				Address = result.Address,
				City = result.City,
				Province = result.Province,
				PostalCode = result.PostalCode,
				StoreName = result.StoreName
			};

			if (result is not null)
			{
				_applicationUser = userFilteredInfo;
			}
			return _applicationUser;
		}
		catch (Exception ex)
		{
			Log.Error(ex.ToString());
			return _applicationUser;
		}
	}

	//* ADDS ApplicationUsers TO DB
	private async Task<bool> AddApplicationUserData(dynamic DBContext, ApplicationUser applicationUser)
	{
		try
		{
			var context = DBContext;
			context.ApplicationUsers.Add(applicationUser);
			var result = context.SaveChanges();
			return result > 0 ? true : false;
		}
		catch (Exception ex)
		{
			Log.Error(ex.ToString());
			return false;
		}
	}

	//* UPDATE ApplicationUsers ON DB
	private async Task<bool> UpdateApplicationUserData(dynamic DBContext, ApplicationUser applicationUser)
	{
		try
		{
			var context = DBContext;
			context.ApplicationUsers.Update(applicationUser);
			var result = context.SaveChanges();
			return result > 0 ? true : false;
		}
		catch (Exception ex)
		{
			Log.Error(ex.ToString());
			return false;
		}
	}

	//* REMOVE/ARCHIVE ApplicationUsers FROM DB
	private async Task<bool> RemoveApplicationUserData(dynamic DBContext, ApplicationUser applicationUser)
	{
		try
		{
			var context = DBContext;
			context.ApplicationUsers.Update(applicationUser);
			var result = context.SaveChanges();
			return result > 0 ? true : false;
		}
		catch (Exception ex)
		{
			Log.Error(ex.ToString());
			return false;
		}
	}
	#endregion
}


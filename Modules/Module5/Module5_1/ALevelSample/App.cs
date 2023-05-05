using System;
using System.Threading.Tasks;
using ALevelSample.Services.Abstractions;
using Newtonsoft.Json;

namespace ALevelSample;

public class App
{
    private readonly IUserService _userService;
    private readonly IResourceService _resourceService;
    private readonly IAuthorizationService _authorizationService;

    public App(IUserService userService, IResourceService resourceService, IAuthorizationService authorizationService)
    {
        _userService = userService;
        _resourceService = resourceService;
        _authorizationService = authorizationService;
    }

    public async Task Start()
    {
        var users = await _userService.GetUsers(3);
        var user = await _userService.GetUserById(2);
        var userNotFound = await _userService.GetUserById(23);
        var userInfo = await _userService.CreateUser("morpheus", "leader");
        Console.WriteLine(JsonConvert.SerializeObject(user));
        var resource = await _resourceService.GetResourceById(2);
        Console.WriteLine(JsonConvert.SerializeObject(resource));
        var resourceNotFound = await _resourceService.GetResourceById(23);

        var resources = await _resourceService.GetResources(1);
        foreach (var res in resources)
        {
            Console.WriteLine(JsonConvert.SerializeObject(res));
        }

        var userUpdate = await _userService.UpdateUserPut(
            2, "morpheus", "zion resident");
        var upUserPach = await _userService.UpdateUserPatch(
            2, "morpheus", "zion resident");

        var delUser = await _userService.DeleteUser(2);

        var registreted = await _authorizationService.Registration("eve.holt@reqres.in", "pistol");
        Console.WriteLine(JsonConvert.SerializeObject(registreted));
        var unRegistreted = await _authorizationService.Registration("sydney@fife");

        var loginUser = await _authorizationService.Login("eve.holt@reqres.in", "cityslicka");
        Console.WriteLine(JsonConvert.SerializeObject(loginUser));
        var notLoginUser = await _authorizationService.Login("peter@klaven");
        Console.WriteLine(JsonConvert.SerializeObject(notLoginUser));
    }
}
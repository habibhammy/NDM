package com.m2gi.genielogiciel.service;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

import com.m2gi.genielogiciel.model.Users;
import com.m2gi.genielogiciel.repository.UsersRepository;

@RestController
@RequestMapping(value="/xamarin/users")
public class UsersService {
	@Autowired
	UsersRepository userrepo;

	/*
	 * Get Methods
	 */
	@RequestMapping(value="/",method = RequestMethod.GET)
	@ResponseBody
	public List<Users> getAllUsers(){
		//System.out.println("gestallusers() ==> "+userrepo.findAll().toString());
		return userrepo.findAll();
	}
	@RequestMapping(value="/{pseudo}",method = RequestMethod.GET,produces={"application/json"})
	@ResponseBody
	public Users getUser(@PathVariable String pseudo){
		//System.out.println("user="+userrepo.getOne(new Long(id)));
		return  userrepo.getOne(pseudo);
	}

	/*
	 * Post Methods
	 */
	@RequestMapping(value="/add",method = RequestMethod.POST)
	public Users addUser(@RequestParam(value="username") String username,
			@RequestParam(value="password") String password,
			@RequestParam(value="email") String email){
		Users user=new Users(username,password,email);
		return userrepo.saveAndFlush(user);
	}

	/*
	 * Put Methods
	 */
	@RequestMapping(value="/update",method = RequestMethod.PUT)
	public Users updateUser(@RequestBody Users user) throws Exception {
		
		if(userrepo.getOne(user.getLogin())!=null){
			if(user.getPassword()== null){
				user.setPassword("000A000");
			}
			System.out.println("update : user="+user.toString());
			userrepo.saveAndFlush(user);
		}else{
			throw new Exception("Users "+user.getLogin()+" does not exists");
		}

		return userrepo.getOne(user.getLogin());
	}

	/*
	 * Delete Methods
	 */
	@RequestMapping(value="/delete/{id}",method = RequestMethod.DELETE)
	public List<Users> deleteStudent(@PathVariable String login) throws Exception {

		Users user = userrepo.getOne(login);

		if(user!=null){
			userrepo.deleteById(user.getLogin());
		}else{
			throw new Exception("Users '"+login+"' does not exists");
		}
		return userrepo.findAll();
	}

}

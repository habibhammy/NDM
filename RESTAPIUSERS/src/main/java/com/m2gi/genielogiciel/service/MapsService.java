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

import com.m2gi.genielogiciel.model.*;
import com.m2gi.genielogiciel.repository.*;

@RestController
@RequestMapping(value="/xamarin/maps")
public class MapsService {

	@Autowired
	MapRepository Maprepo;

	/*
	 * Get Methods
	 */
	@RequestMapping(value="/",method = RequestMethod.GET)
	@ResponseBody
	public List<Maps> getAllLMaps(){
		System.out.println("gestallmaps() ==> "+Maprepo.findAll().toString());
		return Maprepo.findAll();
	}
	@RequestMapping(value="/{id}",method = RequestMethod.GET,produces={"application/json"})
	@ResponseBody
	public Maps getMap(@PathVariable long id){
		//System.out.println("user="+userrepo.getOne(new Long(id)));
		return  Maprepo.getOne(id);
	}

	/*
	 * Post Methods
	 */
	@RequestMapping(value="/add",method = RequestMethod.POST)
	public Maps addMap(@RequestBody Maps maps){
		
		return Maprepo.saveAndFlush(maps);
	}
	/*
	 * Delete Methods
	 */
	@RequestMapping(value="/delete/{id}",method = RequestMethod.DELETE)
	public List<Maps> deleteMap(@PathVariable long id) throws Exception {

		Maps maps= Maprepo.getOne(id);

		if(maps!=null){
			Maprepo.delete(maps.getId());
		}else{
			throw new Exception("map '"+id+"' does not exists");
		}
		return Maprepo.findAll();
	}
	
}

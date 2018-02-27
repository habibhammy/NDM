package com.m2gi.genielogiciel;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.builder.SpringApplicationBuilder;
import org.springframework.boot.web.support.SpringBootServletInitializer;


@SpringBootApplication
public class RestapiusersApplication extends SpringBootServletInitializer{

	@Override
	protected SpringApplicationBuilder configure(SpringApplicationBuilder application){
		return application.sources(RestapiusersApplication.class);
	}

	
	public static void main(String[] args) {
		SpringApplication.run(RestapiusersApplication.class, args);
	}
}

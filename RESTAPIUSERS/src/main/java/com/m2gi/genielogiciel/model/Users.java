package com.m2gi.genielogiciel.model;

import java.util.Date;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.Id;

import com.fasterxml.jackson.annotation.*;
import com.fasterxml.jackson.databind.annotation.JsonSerialize;


@JsonIgnoreProperties({"hibernateLazyInitializer", "handler"})
@Entity(name="Users")
public class Users {

	@Id
	@Column(name="login")
	@JsonProperty(value = "login")
	private String login;
	
	@Column(name="password")
	//@JsonIgnore
    private String password;
	
	@Column(name="nom")
	//@JsonIgnore
    private String nom;
	
	@Column(name="prenom")
	//@JsonIgnore
    private String prenom;
	
	@Column(name="email")
	//@JsonIgnore
    private String email;
	
	@Column(name="birthdate")
	//@JsonIgnore
	@JsonFormat(shape = JsonFormat.Shape.STRING, pattern = "yyyy-MM-dd")
    private Date birthdate;
	
	@Column(name="emailuniversitaire")
	//@JsonIgnore
    private String emailuniversitaire;
	
	public Users(){
	}
    
    public Users(String log , String pw , String em) {
		this.login = log;
		this.password = pw ; 
		this.email = em;
	}
    
    public String getLogin() {
		return login;
	}
    
	public void setLogin(String login) {
		this.login = login;
	}
	
	public String getPassword() {
		return password;
	}
	
	public void setPassword(String password) {
		this.password = password;
	}

	public String getNom() {
		return nom;
	}

	public void setNom(String nom) {
		this.nom = nom;
	}

	public String getPrenom() {
		return prenom;
	}

	public void setPrenom(String prenom) {
		this.prenom = prenom;
	}
	
	public String getEmail() {
		return email;
	}

	public void setEmail(String email) {
		this.email = email;
	}

	public Date getBirthdate() {
		return birthdate;
	}

	public void setBirthdate(Date birthdate) {
		this.birthdate = birthdate;
	}

	public String getEmailuniversitaire() {
		return emailuniversitaire;
	}
	
	public void setEmailuniversitaire(String emailuniversitaire) {
		this.emailuniversitaire = emailuniversitaire;
	}


	@Override
    public String toString() {
        return "User{" +
                "login=" + this.login+ '\''+
                ", emailuniversitaire='" + this.emailuniversitaire + '\'' +
                ", email='" + this.email + '\'' +
                ", firstname='" + this.prenom + '\'' +
                ", lastname='" + this.nom + '\'' +
                ", birthdate='" + this.birthdate + '\'' +
                ", password='" + this.password + '\'' +
                '}';
    }
}

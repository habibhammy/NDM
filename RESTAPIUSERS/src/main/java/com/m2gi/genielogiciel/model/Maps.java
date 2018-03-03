package com.m2gi.genielogiciel.model;

import javax.persistence.*;
import com.fasterxml.jackson.annotation.*;

@JsonIgnoreProperties({"hibernateLazyInitializer", "handler"})
@Entity(name="maps")
public class Maps {

	@Id
	@Column(name="id")
	private long id;
	
	@Column(name="titre")
	private String titre;

	@Column(name="longitude")
	private double longitude;
	
	@Column(name="latitude")
	private double latitude;
	
	@Column(name="description")
	private String description;
	
	public Maps() {
		// TODO Auto-generated constructor stub
	}
	
	public Maps(String titre2, double longitude2, double latitude2, String description2) {
		this.titre = titre2;
		this.longitude=longitude2;
		this.latitude =latitude2;
		this.description =description2;
	}

	public long getId() {
		return id;
	}

	public void setId(long id) {
		this.id = id;
	}

	public String getTitre() {
		return titre;
	}

	public void setTitre(String titre) {
		this.titre = titre;
	}

	public double getLongitude() {
		return longitude;
	}

	public void setLongitude(double longitude) {
		this.longitude = longitude;
	}

	public double getLatitude() {
		return latitude;
	}

	public void setLatitude(double latitude) {
		this.latitude = latitude;
	}

	public String getDescription() {
		return description;
	}

	public void setDescription(String description) {
		this.description = description;
	}

}

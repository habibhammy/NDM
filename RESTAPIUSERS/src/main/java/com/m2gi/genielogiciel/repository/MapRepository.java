package com.m2gi.genielogiciel.repository;

import javax.transaction.Transactional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;

import com.m2gi.genielogiciel.model.Maps;

public interface MapRepository extends JpaRepository<Maps , Long> {

}

package com.m2gi.genielogiciel.repository;

import javax.transaction.Transactional;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;

import com.m2gi.genielogiciel.model.Users;

public interface UsersRepository extends JpaRepository<Users, String> {
	@Modifying
	@Transactional
	@Query(value="delete from Users u where u.login = ?1")
	void deleteById(String string);
	
	
	@Query(value="select u from Users u where u.login= ?1 and u.password = ?2")
	Users getByUserNameandPassword(String username, String password);
	
	
	@Query(value="select u from Users u where u.login= ?1")
	Users getByUserName(String username);
}

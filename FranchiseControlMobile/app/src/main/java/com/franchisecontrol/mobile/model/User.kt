package com.franchisecontrol.mobile.model

data class User(
    val id: Long? = null,
    val username: String? = null,
    val email: String,
    val password: String,
    val photoUrl: String? = null
) 
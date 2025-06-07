package com.franchisecontrol.mobile.network

import com.franchisecontrol.mobile.model.*
import retrofit2.http.Body
import retrofit2.http.GET
import retrofit2.http.POST
import retrofit2.http.Path

interface ApiService {
    @POST("api/Account/login")
    suspend fun login(@Body user: User): retrofit2.Response<Void>

    @POST("api/Account/register")
    suspend fun register(@Body user: User): retrofit2.Response<Void>

    @GET("Franshise")
    suspend fun getFranchises(): List<Franchise>

    @GET("Product")
    suspend fun getProducts(): List<Product>

    @GET("api/Analytic/sales-trends-from/{establishmentId}")
    suspend fun getAnalytics(@Path("establishmentId") establishmentId: Long): List<Analytics>
} 
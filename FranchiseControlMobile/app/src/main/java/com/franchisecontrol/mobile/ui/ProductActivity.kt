package com.franchisecontrol.mobile.ui

import android.os.Bundle
import android.widget.Button
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import com.franchisecontrol.mobile.R

class ProductActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_product)

        val btnAdd = findViewById<Button>(R.id.btnAddProduct)
        btnAdd.setOnClickListener {
            // TODO: Show dialog to add product and call API
            Toast.makeText(this, "Add Product pressed", Toast.LENGTH_SHORT).show()
        }
    }
} 
package com.franchisecontrol.mobile.ui

import android.os.Bundle
import android.widget.Button
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import com.franchisecontrol.mobile.R

class FranchiseActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_franchise)

        val btnAdd = findViewById<Button>(R.id.btnAddFranchise)
        btnAdd.setOnClickListener {
            // TODO: Show dialog to add franchise and call API
            Toast.makeText(this, "Add Franchise pressed", Toast.LENGTH_SHORT).show()
        }
    }
} 
package com.franchisecontrol.mobile.ui

import android.os.Bundle
import android.widget.TextView
import androidx.appcompat.app.AppCompatActivity
import com.franchisecontrol.mobile.R

class AnalyticsActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_analytics)

        val analyticsText = findViewById<TextView>(R.id.textAnalytics)
        // TODO: Load analytics data from API
        analyticsText.text = "Analytics will be shown here."
    }
} 
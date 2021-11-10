package ro.upt.sma

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import android.widget.Button
import android.widget.TextView

class MainActivity : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
        val mButton = findViewById<Button>(R.id.btn_change_text)
        val mText   = findViewById<TextView>(R.id.tv_text_2_display)
        mButton.setOnClickListener(View.OnClickListener { mText.setText("I've been pressed") })
    }
}
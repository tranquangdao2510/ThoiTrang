package com.example.appthoitrang;

import androidx.appcompat.app.ActionBar;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import com.example.appthoitrang.Models.CustomerMangment;
import com.example.appthoitrang.R;

import java.util.HashMap;

public class MyAccountActivity extends AppCompatActivity {

    private Button update_btn;
CustomerMangment customerMangment;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_my_account);

        Toolbar toolbar = findViewById(R.id.toolbarAccount);
        toolbar.setTitle("My Account");
        setSupportActionBar(toolbar);

        // Get a support ActionBar corresponding to this toolbar
        ActionBar ab = getSupportActionBar();
        // Enable the Up button
        ab.setDisplayHomeAsUpEnabled(true);
        customerMangment = new CustomerMangment(this);
        customerMangment.CheckLogin();
        reloadData();
        EditText ta=(EditText)findViewById(R.id.updatelid);
        ta.setVisibility(View.GONE);
        update_btn = findViewById(R.id.update_btn);
        update_btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                actionUpdate();
            }
        });
    }
    private void reloadData(){
        HashMap<String,String> cus = customerMangment.MyAccount();

    }
public void actionUpdate(){

}
}
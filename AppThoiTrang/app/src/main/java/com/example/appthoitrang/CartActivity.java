package com.example.appthoitrang;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.RecyclerView;

import android.os.Bundle;
import android.widget.Button;

import com.example.appthoitrang.Models.CustomerMangment;
import com.example.appthoitrang.R;

public class CartActivity extends AppCompatActivity {
    private RecyclerView recyclerView;
    CustomerMangment customerMangment;
    Button btnCheckoutProduct;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_cart);
        customerMangment= new CustomerMangment(this);

    }

}
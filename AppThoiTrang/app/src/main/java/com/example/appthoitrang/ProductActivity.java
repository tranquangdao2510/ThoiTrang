package com.example.appthoitrang;

import androidx.appcompat.app.ActionBar;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;
import androidx.recyclerview.widget.GridLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.os.Bundle;

import com.example.appthoitrang.R;

public class ProductActivity extends AppCompatActivity {

    private RecyclerView recyclerView;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_product);
        Toolbar toolbar = findViewById(R.id.itemToolBarCategory);
        toolbar.setTitle("Product");
setSupportActionBar(toolbar);
recyclerView = findViewById(R.id.listProd);
recyclerView.setHasFixedSize(true);
recyclerView.setLayoutManager(new GridLayoutManager(this, 2));
        ActionBar actionBar =getSupportActionBar();
actionBar.setDisplayHomeAsUpEnabled(true);
    }
}
package com.example.appthoitrang;

import androidx.appcompat.app.ActionBar;
import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.os.Bundle;
import android.widget.Toolbar;

import com.android.volley.Response;
import com.example.appthoitrang.R;

public class CategoryActivity extends AppCompatActivity {

    private RecyclerView recyclerView;
    private final Response.Listener<String> listener = new Response.Listener<String>() {
        @Override
        public void onResponse(String response) {
            return;
        }
    };

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_category);

        androidx.appcompat.widget.Toolbar toolbar = findViewById(R.id.itemToolBarCategory);
        toolbar.setTitle("Category");
        setSupportActionBar(toolbar);
        recyclerView = findViewById(R.id.listCate);
        recyclerView.setHasFixedSize(true);
        recyclerView.setLayoutManager(new LinearLayoutManager(this));
// nhận giá trị tương ứng khi nhấn action bar
        ActionBar actionBar = getSupportActionBar();
// hiển thị lên nút ấn
        actionBar.setDisplayHomeAsUpEnabled(true);
    }
}
package com.example.appthoitrang;

import androidx.appcompat.app.ActionBar;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;
import androidx.recyclerview.widget.GridLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.os.Bundle;
import android.util.Log;

import com.android.volley.RequestQueue;
import com.android.volley.VolleyError;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;
import com.example.appthoitrang.Adapters.AdapterProduct;
import com.example.appthoitrang.Models.Product;
import com.google.gson.*;

import com.android.volley.Response;
import com.example.appthoitrang.R;

public class ProductActivity extends AppCompatActivity {

    private RecyclerView recyclerView;
    private final Response.Listener<String> listener = new Response.Listener<String>() {
        @Override
        public void onResponse(String response) {
            try {
                Log.e("BKAP","Json" + response);
                GsonBuilder gsonBuilder =new GsonBuilder();
Gson gson  = gsonBuilder.create();
                Product data[] =gson.fromJson(response, Product[].class);
                AdapterProduct adapterProduct= new AdapterProduct(ProductActivity.this, data);
                recyclerView.setAdapter(adapterProduct);
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
    };
    private Response.ErrorListener errorListener= new Response.ErrorListener() {
        @Override
        public void onErrorResponse(VolleyError error) {
            Log.e("BKAP","ERROR: " + error.getMessage());
        }
    };

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_product);
        Toolbar toolbar = findViewById(R.id.itemToolBarProduct);
        toolbar.setTitle("Product");
        setSupportActionBar(toolbar);
        loadJson();
        recyclerView = findViewById(R.id.listProd);
        recyclerView.setHasFixedSize(true);
        recyclerView.setLayoutManager(new GridLayoutManager(this, 2));
        ActionBar actionBar = getSupportActionBar();
        actionBar.setDisplayHomeAsUpEnabled(true);
    }

    private void loadJson(){
        Host host = new Host();
        String url ="http://" + host.getHost() + ":8183/api/list_product";
        RequestQueue queue = Volley.newRequestQueue(this);
        StringRequest stringRequest = new StringRequest(url,listener,errorListener);

        queue.add(stringRequest);
    }
}
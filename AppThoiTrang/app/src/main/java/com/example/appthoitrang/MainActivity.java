package com.example.appthoitrang;

import androidx.annotation.NonNull;
import androidx.appcompat.app.ActionBarDrawerToggle;
import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;
import androidx.core.view.GravityCompat;
import androidx.drawerlayout.widget.DrawerLayout;
import androidx.recyclerview.widget.GridLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.animation.Animation;
import android.view.animation.AnimationUtils;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;
import android.widget.ViewFlipper;

import com.android.volley.Response;
import com.android.volley.VolleyError;
import com.example.appthoitrang.Models.CustomerMangment;
import com.example.appthoitrang.Models.Product;
import com.google.android.material.floatingactionbutton.FloatingActionButton;
import com.google.android.material.navigation.NavigationView;

import java.util.ArrayList;

public class MainActivity extends AppCompatActivity implements NavigationView.OnNavigationItemSelectedListener {

    Toolbar toolbar;
    ViewFlipper viewFlipper;
    DrawerLayout drawerLayout;
    LinearLayout listView;
    CustomerMangment customerMangment;


    private RecyclerView recyclerView;
    private final Response.Listener<String> listener = new Response.Listener<String>() {
        @Override
        public void onResponse(String response) {
            try {
                Log.e("BKAP", "JSON: " + response);
//               GsonBuilder builder = new GsonBuilder();
//               Gson gson = builder.create();
//                Product data[] = gson.fromJson(response, Product[].class);
////                AdapterHome adapter = new AdapterHome(MainActivity.this,data);
//                recyclerView.setAdapter(adapter);
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
        setContentView(R.layout.activity_main);

        customerMangment = new CustomerMangment();
        AnhXa();
        ActionBar();
        ActionViewFliper();
        //Chuyển trang giỏ hàng
        FloatingActionButton cart = (FloatingActionButton) findViewById(R.id.fab);
        cart.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent=new Intent(MainActivity.this,CartActivity.class);
                startActivity(intent);

            }
        });
        //loadJSON();
        recyclerView =findViewById(R.id.listProduct);
        recyclerView.setHasFixedSize(true);
        recyclerView.setLayoutManager(new GridLayoutManager(this,2));

        NavigationView navigationView = (NavigationView) findViewById(R.id.nav_view);
        navigationView.setNavigationItemSelectedListener(this);
        View headerView=navigationView.getHeaderView(0);
        TextView userNameTxtView=headerView.findViewById(R.id.username);
//        HashMap<String,String> cus= customerMangment.myaccount();
//        String mEmail = cus.get(customerMangment.EMAIL);

//        userNameTxtView.setText(mEmail);

    }
    private void ActionViewFliper(){
        ArrayList<String> mangbanner = new ArrayList<>();
        mangbanner.add("https://apollotran.b-cdn.net/prestashop/leo_minimal_demo/themes/leo_minimal/assets/img/modules/leoslideshow/bg-slide-3-1.jpg");
        mangbanner.add("https://apollotran.b-cdn.net/prestashop/leo_minimal_demo/themes/leo_minimal/assets/img/modules/leoslideshow/bg-slide-3-2.jpg");
        mangbanner.add("https://apollotran.b-cdn.net/prestashop/leo_minimal_demo/themes/leo_minimal/assets/img/modules/leoslideshow/bg-slide-2-1.jpg");
        for (int i=0;i<mangbanner.size(); i++){
            ImageView imageView = new ImageView(getApplicationContext());
//           Picasso.with(getApplicationContext()).load(mangbanner.get(i)).into(imageView);
            imageView.setScaleType(ImageView.ScaleType.FIT_XY);
            viewFlipper.addView(imageView);
        }
        viewFlipper.setFlipInterval(5000);
        viewFlipper.setAutoStart(true);
        Animation animation_slide_in = AnimationUtils.loadAnimation(getApplicationContext(),R.anim.slide_in_right);
        Animation animation_slide_out = AnimationUtils.loadAnimation(getApplicationContext(),R.anim.slide_out_right);
        viewFlipper.setInAnimation(animation_slide_in);
        viewFlipper.setOutAnimation(animation_slide_out);

    }
    @SuppressLint("RestrictedApi")
    private void ActionBar(){
        androidx.appcompat.widget.Toolbar toolbar = findViewById(R.id.toolbartrangchu);
        toolbar.setTitle("Trang chủ");
        setSupportActionBar(toolbar);


        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawerlayout);
        ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(
                this, drawer, toolbar, R.string.navigation_drawer_open, R.string.navigation_drawer_close);
        drawer.addDrawerListener(toggle);
        toggle.syncState();

        NavigationView navigationView = (NavigationView) findViewById(R.id.nav_view);
        navigationView.setNavigationItemSelectedListener(this);

    }
    private void AnhXa(){
        toolbar= findViewById(R.id.toolbartrangchu);
        viewFlipper =  findViewById(R.id.viewflipper);
        //recyclerViewTrangChu = findViewById(R.id.recyclerview);
        drawerLayout = findViewById(R.id.drawerlayout);
    }
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        MenuInflater inflater=getMenuInflater();
        inflater.inflate(R.menu.home, menu);
        return super.onCreateOptionsMenu(menu);

        // Associate searchable configuration with the SearchView
//        SearchManager searchManager =
//                (SearchManager) getSystemService(Context.SEARCH_SERVICE);
//        SearchView searchView =
//                (SearchView) menu.findItem(R.id.action_search).getActionView();
//        ComponentName componentName=new ComponentName(getBaseContext(),SearchResultActivity.class);
//        searchView.setSearchableInfo(
//                searchManager.getSearchableInfo(componentName));

        //return true;
    }
    @Override
    public void onBackPressed() {
        DrawerLayout drawer = (DrawerLayout) findViewById(R.id.drawerlayout);
        if (drawer.isDrawerOpen(GravityCompat.START)) {
            drawer.closeDrawer(GravityCompat.START);
        } else {
            super.onBackPressed();
        }
    }
    @SuppressWarnings("StatementWithEmptyBody")
    @Override
    public boolean onNavigationItemSelected(@NonNull MenuItem item) {
        int id = item.getItemId();
        switch (id) {
            case R.id.nav_home:
                Intent intent_home = new Intent(MainActivity.this, MainActivity.class);
                startActivity(intent_home);
                break;
            case R.id.nav_shop:
                Intent intent_shop = new Intent(MainActivity.this, MainActivity.class);
                startActivity(intent_shop);
                break;
            case R.id.nav_product:
                Intent intent_product = new Intent(MainActivity.this, MainActivity.class);
                startActivity(intent_product);
                break;
            case R.id.nav_like:
                Intent intent_like = new Intent(MainActivity.this, MainActivity.class);
                startActivity(intent_like);
                break;
            case R.id.nav_contact_us:
                Intent intent_contact = new Intent(MainActivity.this, MainActivity.class);
                startActivity(intent_contact);
                break;
            case R.id.nav_my_account:
                Intent intent_account = new Intent(MainActivity.this, MainActivity.class);
                startActivity(intent_account);
                break;
            case R.id.nav_order:
                Intent intent_order = new Intent(MainActivity.this, MainActivity.class);
                startActivity(intent_order);
                break;
            case R.id.nav_sign_out:
                Intent intent_sign_out = new Intent(MainActivity.this, MainActivity.class);
                startActivity(intent_sign_out);
                break;
            default:
                throw new IllegalStateException("Unexpected value: " + id);
        }

        DrawerLayout drawerLayout = (DrawerLayout) findViewById(R.id.drawerlayout);
        drawerLayout.closeDrawer(GravityCompat.START);

        return true;
    }

//    private void loadJSON() {
//        Host host = new Host();
//        String url = "http://" + host.getHost() + ":8183/api/list_product?sort=1";
//        RequestQueue queue = Volley.newRequestQueue(this);
//        StringRequest stringRequest = new StringRequest(url, listener, errorListener);
//
//        queue.add(stringRequest);
//    }
}
package com.example.appthoitrang.Models;

import androidx.annotation.GravityInt;
import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.view.GravityCompat;
import androidx.drawerlayout.widget.DrawerLayout;
import androidx.navigation.Navigation;

import android.content.Intent;
import android.graphics.drawable.Drawable;
import android.os.Bundle;
import android.view.MenuItem;

import com.example.appthoitrang.R;
import com.google.android.material.navigation.NavigationView;

public class MainActivity extends AppCompatActivity implements NavigationView.OnNavigationItemSelectedListener {


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

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
}
package com.example.appthoitrang.Models;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;

import com.example.appthoitrang.LoginActivity;
import com.example.appthoitrang.MainActivity;
import com.example.appthoitrang.MyAccountActivity;

import java.util.HashMap;
import java.util.HashSet;

public class CustomerMangment {
    Context context;
    SharedPreferences sharedPreferences;
    public SharedPreferences.Editor editor;
    public static final String PREE_NAME = "Customer_Login";
    public static final String LOGIN = "is_customer_login";
    public static final String NAME = "name";
    public static final String EMAIL = "email";
    public static final String PHONE = "phone";
    public static final String ADDRESS = "address";

    public CustomerMangment(Context context) {
        this.context = context;
        sharedPreferences = context.getSharedPreferences(PREE_NAME, context.MODE_PRIVATE);
        editor = sharedPreferences.edit();
    }

    private boolean isCusLogin() {
        return sharedPreferences.getBoolean(LOGIN, false);
    }

    public void CustomerSessionManager(String name, String email, String phone, String address) {
        editor.putBoolean(LOGIN, true);
        editor.putString(NAME, name);
        editor.putString(EMAIL, email);
        editor.putString(PHONE, phone);
        editor.putString(ADDRESS, address);
        editor.apply();
    }

    public void CheckLogin() {
        if (!this.isCusLogin()) {
            Intent intent = new Intent(context, MainActivity.class);
            context.startActivity(intent);
            ((MyAccountActivity) context).finish();
        }
    }

    public HashMap<String, String> MyAccount() {
        HashMap<String, String> cus = new HashMap<>();
        cus.put(NAME, sharedPreferences.getString(NAME, null));
        cus.put(EMAIL, sharedPreferences.getString(EMAIL, null));
        cus.put(PHONE, sharedPreferences.getString(PHONE, null));
        cus.put(ADDRESS, sharedPreferences.getString(ADDRESS, null));
        return cus;
    }

    public void Logout() {
        editor.clear();
        editor.commit();
        Intent intent = new Intent(context, LoginActivity.class);
        context.startActivity(intent);
        ((MyAccountActivity) context).finish();
    }
}

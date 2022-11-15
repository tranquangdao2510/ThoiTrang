package com.example.appthoitrang.Adapters;

import android.content.Context;
import android.content.Intent;
import android.graphics.Paint;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.example.appthoitrang.DetailProductActivity;
import com.example.appthoitrang.Host;
import com.example.appthoitrang.Models.Product;
import com.example.appthoitrang.R;
import com.example.appthoitrang.DetailProductActivity;
import com.example.appthoitrang.Host;
import com.example.appthoitrang.Models.Product;
import com.squareup.picasso.Picasso;

public class AdapterHome extends RecyclerView.Adapter<AdapterHome.PosHolder>{
    Product data[];
    private Context mContext;

    public AdapterHome(Context context, Product[] data) {
        this.mContext = context;
        this.data = data;
    }

    @NonNull
    @Override
    public PosHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.product_new,parent,false);
        return new PosHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull PosHolder holder, int position) {
        Host host = new Host();
        holder.namePro.setText(data[position].getName());
        Picasso.with(holder.namePro.getContext())
                .load("http://" + host.getHost() + ":8183/upload/image_product/"
                        +data[position].getImage()).into(holder.imgPro);
        holder.pricePro.setText(Double.toString(data[position].getPrice()) + " VND");

        // custom gạch giá
        if (!holder.priceSale.getPaint().isStrikeThruText()) {
            holder.priceSale.setPaintFlags(holder.priceSale.getPaintFlags() | Paint.STRIKE_THRU_TEXT_FLAG);
        } else {
            holder.priceSale.setPaintFlags(holder.priceSale.getPaintFlags() & ~Paint.STRIKE_THRU_TEXT_FLAG);
        }
        holder.priceSale.setText(Double.toString(data[position].getSale_price()) + " VND");

        int id = data[position].getId();
        holder.layoutItem.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                onClickDetail(id);
            }
        });

    }

    private void onClickDetail(int id) {
        Intent intent = new Intent(mContext, DetailProductActivity.class);
        Bundle bundle = new Bundle();
        bundle.putSerializable("id_product", id);
        intent.putExtras(bundle);
        mContext.startActivity(intent);
    }

    @Override
    public int getItemCount() {
        return data.length;
    }

    public class PosHolder extends RecyclerView.ViewHolder{
        ImageView imgPro;
        TextView namePro;
        TextView pricePro;
        TextView priceSale;
        LinearLayout layoutItem;

        public PosHolder(@NonNull View itemView){
            super(itemView);
            imgPro = itemView.findViewById(R.id.imgPro);
            namePro = itemView.findViewById(R.id.namePro);
            pricePro = itemView.findViewById(R.id.pricePro);
            priceSale = itemView.findViewById(R.id.priceSale);
            layoutItem = itemView.findViewById(R.id.itemProduct);
        }
    }
}

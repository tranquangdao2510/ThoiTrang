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
import androidx.cardview.widget.CardView;
import androidx.recyclerview.widget.RecyclerView;

import com.example.appthoitrang.DetailProductActivity;
import com.example.appthoitrang.Host;
import com.example.appthoitrang.Models.Product;
import com.example.appthoitrang.R;
import com.squareup.picasso.Picasso;

public class AdapterProduct extends RecyclerView.Adapter<AdapterProduct.PosHolder> {
    Product data[];
    private Context mcontext;

    public AdapterProduct(Context context, Product[] data) {
        this.mcontext = context;
        this.data = data;
    }

    @NonNull
    @Override
    public AdapterProduct.PosHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(parent.getContext()).inflate(R.layout.product_list,parent,false);
        return new PosHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull PosHolder holder, int position) {
        Host host = new Host();
        holder.namePro.setText(data[position].getName());
        Picasso.with(holder.namePro.getContext())
                .load("http://" + host.getHost() + ":8183/upload/image_product/"+data[position].getImage()).into(holder.item_img_product);
holder.price.setText(Double.toString(data[position].getPrice()) + "VND");
holder.item_daban_id.setText(Integer.toString(data[position].getView()));
        if (!holder.priceSale.getPaint().isStrikeThruText()) {
            holder.priceSale.setPaintFlags(holder.priceSale.getPaintFlags() | Paint.STRIKE_THRU_TEXT_FLAG);
        } else {
            holder.priceSale.setPaintFlags(holder.priceSale.getPaintFlags() & ~Paint.STRIKE_THRU_TEXT_FLAG);
        }
        holder.priceSale.setText(Double.toString(data[position].getSale_price()) + " VND");
        int id = data[position].getId();
        holder.getImgPro().setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                onClickDetail(id);
            }
        });
    }

    public void onClickDetail(int id){
        Intent intent = new Intent(mcontext, DetailProductActivity.class);
        Bundle bundle = new Bundle();
        bundle.putSerializable("id_product", id);
        intent.putExtras(bundle);
        mcontext.startActivity(intent);

    }
    @Override
    public int getItemCount() {
        return data.length;
    }

    public class PosHolder extends RecyclerView.ViewHolder {
        ImageView item_img_product;
        TextView namePro;
        TextView price;
        TextView priceSale;
        TextView item_daban_id;
        CardView cardView;
        LinearLayout layoutItem;

        public PosHolder(@NonNull View itemView) {
            super(itemView);
            item_img_product = itemView.findViewById(R.id.item_img_product);
            namePro = itemView.findViewById(R.id.namePro);
            price = itemView.findViewById(R.id.price);
            priceSale = itemView.findViewById(R.id.priceSale);
            item_daban_id = itemView.findViewById(R.id.item_daban_id);
            cardView = itemView.findViewById(R.id.card_view_product);
            layoutItem = itemView.findViewById(R.id.item_product);
        }
        public ImageView getImgPro() {
            return item_img_product;
        }
    }
}
